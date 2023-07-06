using Gameplay.Movement.Comps;
using Gameplay.Unit.Behavior.ECS.Comps;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;

namespace Gameplay.Unit.Behavior.ECS.Sys {
   public class MoveByPathSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Path>          _pathPool;
      private EcsPool<MoveDirection> _moveDirectionPool;



      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<Path>()
                         .Inc<MoveDirection>()
                         .Inc<EcsTransform>()
                         .End();

         _pathPool          = _world.GetPool<Path>();
         _moveDirectionPool = _world.GetPool<MoveDirection>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            _moveDirectionPool.Get(e).value = _pathPool.Get(e).MoveDirection();
         }
      }
   }
}