using Leopotam.EcsLite;

namespace ECS.Unit.Behavior.Comps {
   public class ProcessBehaviorSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Behavior> _behaviorPool;

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<Behavior>().End();

         _behaviorPool = _world.GetPool<Behavior>();
      }



      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) _behaviorPool.Get(e).Tree.Run(e, _world);
      }
   }
}