using Extensions.Ecs;
using Gameplay.Player.Comps;
using Gameplay.Weapon._base;
using Gameplay.Weapon.Aim;
using Gameplay.Weapon.Ammo.Comps;
using Gameplay.Weapon.Ammo.Reload;
using Gameplay.Weapon.Attack.Comps;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Lab {
   public class TestPlayerInputSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<WeaponOwner> _weaponOwnerPool;
      private EcsPool<AimPosition> _aimPositionPool;
      private EcsPool<WantAttack>  _wantShootPool;
      private EcsPool<WantReload>  _wantReloadPool;
      private EcsPool<Magazine>    _magazinePool;
      private EcsPool<Reload>      _reloadPool;



      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<Player>()
                         .Inc<WeaponOwner>()
                         .Inc<AimPosition>()
                         .End();

         _weaponOwnerPool = _world.GetPool<WeaponOwner>();
         _wantShootPool   = _world.GetPool<WantAttack>();
         _aimPositionPool = _world.GetPool<AimPosition>();
         _wantReloadPool  = _world.GetPool<WantReload>();
         _magazinePool    = _world.GetPool<Magazine>();
         _reloadPool      = _world.GetPool<Reload>();
      }

      public void Run(IEcsSystems systems) {
         Vector2 mousePos   = MouseUtils.WorldPos2D();
         bool    wantAttack = MouseUtils.RightBtn();
         bool    wantReload = Keyboard.current.rKey.wasPressedThisFrame;

         foreach (int playerE in _filter) {
            if (!HasWeapon(playerE, out int weaponE))
               continue;

            ShootOrStop(weaponE, wantAttack);
            ReloadIfEmpty(weaponE, wantAttack, wantReload);
            AimAt(playerE, mousePos);
         }
      }



      private void ShootOrStop(int weaponE, bool wantAttack) {
         if (wantAttack)
            _wantShootPool.TryAdd(weaponE);
         else
            _wantShootPool.TryDel(weaponE);
      }

      private void ReloadIfEmpty(int weaponE, bool wantAttack, bool wantReload) {
         if (wantReload || (EmptyMagazine(weaponE) && (wantAttack || ReloadAuto(weaponE))))
            _wantReloadPool.TryAdd(weaponE);
      }



      private bool HasWeapon(int ownerE, out int weaponE) {
         weaponE = -1;
         return _weaponOwnerPool.Get(ownerE).weapon?.Unpack(out _, out weaponE) == true;
      }



      private void AimAt(int         playerE, Vector2 pos) => _aimPositionPool.Get(playerE).value = pos;
      private bool ReloadAuto(int    weaponE) => _reloadPool.TryGet(weaponE, out Reload r)            && r.auto;
      private bool EmptyMagazine(int weaponE) => _magazinePool.TryGet(weaponE, out Magazine magazine) && magazine.IsEmpty();
   }
}