using Extentions;
using Leopotam.EcsLite;

namespace Weapon.Aim {
  public class AimSys : IEcsRunSystem, IEcsInitSystem {
    private EcsWorld  _world;
    private EcsFilter _filter;

    private EcsPool<ActiveWeapons> _activeWeaponsPool;
    private EcsPool<AimPosition>   _aimPositionPool;
    private EcsPool<EcsTransform>  _ecsTransformPool;



    public void Run(IEcsSystems systems) {
      foreach (int ownerE in _filter) {
        ref ActiveWeapons activeWeapons = ref _activeWeaponsPool.Get(ownerE);
        ref AimPosition   aimPosition   = ref _aimPositionPool.Get(ownerE);

        foreach (EcsPackedEntity weapon in activeWeapons.weapons) {
          if (HasTransform(weapon, out int weaponE))
            _ecsTransformPool
             .Get(weaponE)
             .LookAt2D(aimPosition.value);
        }
      }
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world.Filter<ActiveWeapons>()
                      .Inc<AimPosition>()
                      .End();

      _activeWeaponsPool = _world.GetPool<ActiveWeapons>();
      _aimPositionPool   = _world.GetPool<AimPosition>();
      _ecsTransformPool  = _world.GetPool<EcsTransform>();
    }

    

    private bool HasTransform(EcsPackedEntity weapon,       out int weaponE) => GetEntity(weapon, out weaponE) && _ecsTransformPool.Has(weaponE);
    private bool GetEntity(EcsPackedEntity    activeWeapon, out int weaponE) => activeWeapon.Unpack(_world, out weaponE);
  }
}