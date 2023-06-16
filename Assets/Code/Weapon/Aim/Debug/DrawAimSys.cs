using Debug;
using Extensions.Ecs;
using Leopotam.EcsLite;
using UnityEngine;

namespace Weapon.Aim.Debug {
  public class DrawAimSys : IEcsRunSystem, IEcsInitSystem {
    private readonly GizmosService _gizmos;
    private          EcsWorld      _world;
    private          EcsFilter     _filter;

    private EcsPool<AimPosition>  _aimPositionPool;
    private EcsPool<EcsTransform> _ecsTransformPool;



    public DrawAimSys(GizmosService gizmos) {
      _gizmos = gizmos;
    }

    public void Run(IEcsSystems systems) {
      foreach (int e in _filter) {
        Vector3 aimPos = _aimPositionPool.Get(e).value;

        _gizmos.Draw(
          () => {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(aimPos, .1f);
            
            if (_ecsTransformPool.TryGet(e, out EcsTransform t))
              Gizmos.DrawLine(t.Position, aimPos);
          }
        );
      }
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world
               .Filter<AimPosition>()
               .End();

      _aimPositionPool  = _world.GetPool<AimPosition>();
      _ecsTransformPool = _world.GetPool<EcsTransform>();
    }
  }
}