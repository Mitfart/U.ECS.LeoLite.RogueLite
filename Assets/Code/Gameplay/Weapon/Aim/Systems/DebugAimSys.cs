using Extensions.Ecs;
using Gameplay.UnityRef.Transform.Comp;
using Infrastructure.Services.Gizmos;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Weapon.Aim.Debug {
   public class DebugAimSys : IEcsRunSystem, IEcsInitSystem {
      private readonly GizmosService _gizmos;
      private          EcsWorld      _world;
      private          EcsFilter     _filter;

      private EcsPool<AimPosition>  _aimPositionPool;
      private EcsPool<EcsTransform> _ecsTransformPool;



      public DebugAimSys(GizmosService gizmos) {
         _gizmos = gizmos;
      }

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<AimPosition>().End();

         _aimPositionPool  = _world.GetPool<AimPosition>();
         _ecsTransformPool = _world.GetPool<EcsTransform>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            Vector3 aimPos = _aimPositionPool.Get(e).value;

            _gizmos.Draw(
               () => {
                  Gizmos.color = Color.cyan;
                  Gizmos.DrawSphere(aimPos, radius: .1f);

                  if (_ecsTransformPool.TryGet(e, out EcsTransform t))
                     Gizmos.DrawLine(t.Position, aimPos);
               }
            );
         }
      }
   }
}