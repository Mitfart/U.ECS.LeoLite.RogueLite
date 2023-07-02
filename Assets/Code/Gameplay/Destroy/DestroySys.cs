using Leopotam.EcsLite;

namespace Destroy {
   public class DestroySys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<Destroy>().End();
      }


      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            _world.DelEntity(e);
         }
      }
   }
}