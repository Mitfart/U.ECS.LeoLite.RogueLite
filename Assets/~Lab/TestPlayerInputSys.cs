using Battle.Weapon;
using Battle.Weapon.Aim;
using Battle.Weapon.Ammo;
using Battle.Weapon.Ammo._base;
using Battle.Weapon.Ammo.Reload;
using Battle.Weapon.Attack;
using Extensions.Ecs;
using Leopotam.EcsLite;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Lab {
  public class TestPlayerInputSys : IEcsRunSystem, IEcsInitSystem {
    private EcsWorld  _world;
    private EcsFilter _filter;

    private EcsPool<ActiveWeapons> _activeWeaponPool;
    private EcsPool<AimPosition>   _aimPositionPool;
    private EcsPool<WantAttack>    _wantShootPool;
    private EcsPool<WantReload>    _wantReloadPool;
    private EcsPool<AutoReload>    _autoReloadPool;
    private EcsPool<Magazine>      _magazinePool;



    public void Run(IEcsSystems systems) {
      Vector2 mousePos     = MouseUtils.WorldPos2D();
      bool    shootBtnDown = MouseUtils.RightBtnDown();
      bool    shootBtnUp   = MouseUtils.RightBtnUp();
      bool    reloadKey    = Keyboard.current.rKey.wasPressedThisFrame;

      foreach (int e in _filter) {
        foreach (EcsPackedEntity activeWeapon in _activeWeaponPool.Get(e).weapons) {
          if (!activeWeapon.Unpack(_world, out int e2))
            continue;

          ShootOrStop(e2, shootBtnDown, shootBtnUp);
          ReloadIfEmpty(e2, shootBtnDown, reloadKey);
          AimAtMouse(e, mousePos);
        }
      }
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world.Filter<PlayerTag>()
                      .Inc<ActiveWeapons>()
                      .End();

      _activeWeaponPool = _world.GetPool<ActiveWeapons>();
      _wantShootPool    = _world.GetPool<WantAttack>();
      _aimPositionPool  = _world.GetPool<AimPosition>();
      _wantReloadPool   = _world.GetPool<WantReload>();
      _magazinePool     = _world.GetPool<Magazine>();
      _autoReloadPool   = _world.GetPool<AutoReload>();
    }



    private void ShootOrStop(int e2, bool shootBtnDown, bool shootBtnUp) {
      if (shootBtnDown)
        _wantShootPool.TryAdd(e2);
      else if (shootBtnUp)
        _wantShootPool.TryDel(e2);
    }

    private void ReloadIfEmpty(int e2, bool shootBtnDown, bool reload) {
      bool magazineIsEmpty = _magazinePool.TryGet(e2, out Magazine magazine) && magazine.IsEmpty();

      if (reload || (magazineIsEmpty && (shootBtnDown || _autoReloadPool.Has(e2))))
        _wantReloadPool.TryAdd(e2);
    }

    private void AimAtMouse(int e, Vector2 mousePos) {
      if (_aimPositionPool.Has(e))
        _aimPositionPool.Get(e).value = mousePos;
    }
  }
}