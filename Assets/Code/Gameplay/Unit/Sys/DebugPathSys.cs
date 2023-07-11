using Gameplay.Unit.Behavior.ECS.Comps;
using Infrastructure.Services.Gizmos;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Unit.Behavior.ECS.Debug {
   public class DebugPathSys : IEcsRunSystem, IEcsInitSystem {
      private readonly GizmosService _gizmosService;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Path> _pathPool;



      public DebugPathSys(GizmosService gizmosService) {
         _gizmosService = gizmosService;
      }

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<Path>().End();

         _pathPool = _world.GetPool<Path>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            Path path = _pathPool.Get(e);
            
            if (!path.Exist)
               continue;

            _gizmosService.Draw(
               () => {
                  for (var i = 0; i < path.MaxIndex; i++) {
                     Vector3 corner     = path.Corners[i];
                     Vector3 nextCorner = path.Corners[i + 1];

                     Gizmos.color = Color.green;
                     Gizmos.DrawLine(corner, nextCorner);
                  }

                  Gizmos.color = Color.magenta;
                  Gizmos.DrawLine(path.Corner(), path.NextCorner());
               }
            );
         }
      }
   }
}