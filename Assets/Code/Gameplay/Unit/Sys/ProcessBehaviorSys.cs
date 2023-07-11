using Gameplay.Unit.Behavior.ECS.Comps;
using Leopotam.EcsLite;

namespace Gameplay.Unit.Behavior.ECS.Sys {
   public class ProcessBehaviorSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<AI> _behaviorPool;

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<AI>().End();

         _behaviorPool = _world.GetPool<AI>();
      }



      public void Run(IEcsSystems systems) {
         foreach (int e in _filter)
            _behaviorPool.Get(e).Behavior.Run();
      }
   }
}