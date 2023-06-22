using Extensions.Ecs;
using Features.Player;
using Features.Weapon;
using Features.Weapon.Aim;
using Features.Weapon.Ammo._base;
using Features.Weapon.Ammo.Extensions;
using Features.Weapon.Ammo.Reload;
using Features.Weapon.Attack;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Lab {
  public class TestPlayerInputSys : IEcsRunSystem, IEcsInitSystem {
    private EcsWorld  _world;
    private EcsFilter _filter;

    private EcsPool<WeaponOwner> _activeWeaponPool;
    private EcsPool<AimPosition>   _aimPositionPool;
    private EcsPool<WantAttack>    _wantShootPool;
    private EcsPool<WantReload>    _wantReloadPool;
    private EcsPool<AutoReload>    _autoReloadPool;
    private EcsPool<Magazine>      _magazinePool;



    public void Run(IEcsSystems systems) {
      if (_filter.GetEntitiesCount() <= 0)
        return;
      
      Vector2 mousePos     = MouseUtils.WorldPos2D();
      bool    shootBtnDown = MouseUtils.RightBtnDown();
      bool    shootBtnUp   = MouseUtils.RightBtnUp();
      bool    reloadKey    = Keyboard.current.rKey.wasPressedThisFrame;

      foreach (int playerE in _filter) {
        if (!_activeWeaponPool.Get(playerE).Weapon.Unpack(_world, out int weaponE))
          continue;

        ShootOrStop(weaponE, shootBtnDown, shootBtnUp);
        ReloadIfEmpty(weaponE, shootBtnDown, reloadKey);
        AimAtMouse(playerE, mousePos);
      }
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world.Filter<PlayerTag>()
                      .Inc<WeaponOwner>()
                      .End();

      _activeWeaponPool = _world.GetPool<WeaponOwner>();
      _wantShootPool    = _world.GetPool<WantAttack>();
      _aimPositionPool  = _world.GetPool<AimPosition>();
      _wantReloadPool   = _world.GetPool<WantReload>();
      _magazinePool     = _world.GetPool<Magazine>();
      _autoReloadPool   = _world.GetPool<AutoReload>();
    }



    private void ShootOrStop(int weaponE, bool shootBtnDown, bool shootBtnUp) {
      if (shootBtnDown)
        _wantShootPool.TryAdd(weaponE);
      else if (shootBtnUp)
        _wantShootPool.TryDel(weaponE);
    }

    private void ReloadIfEmpty(int weaponE, bool shootBtnDown, bool reload) {
      bool magazineIsEmpty = _magazinePool.TryGet(weaponE, out Magazine magazine) && magazine.IsEmpty();

      if (reload || (magazineIsEmpty && (shootBtnDown || _autoReloadPool.Has(weaponE))))
        _wantReloadPool.TryAdd(weaponE);
    }

    private void AimAtMouse(int playerE, Vector2 mousePos) {
      if (_aimPositionPool.Has(playerE))
        _aimPositionPool.Get(playerE).value = mousePos;
    }
  }
}