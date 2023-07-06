using Extensions;
using Gameplay.Player.Comps;
using Gameplay.Unit.Behavior.ECS.Comps;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Unit.Behavior.ECS.Sys {
   public class ProcessPathSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Path>         _pathPool;
      private EcsPool<EcsTransform> _ecsTransformPool;



      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<Path>()
                         .Inc<PlayerTag>()
                         .Inc<EcsTransform>()
                         .End();

         _pathPool         = _world.GetPool<Path>();
         _ecsTransformPool = _world.GetPool<EcsTransform>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            ref Path path = ref _pathPool.Get(e);

            var distance = Vector3.Distance(Position(e), path.NextCorner());

            if (path.exist && distance <= 1)
               path.cornerIndex = path.NextCornerIndex;
         }
      }

      private Vector3 Position(int entity) => _ecsTransformPool.Get(entity).Position;
   }
}