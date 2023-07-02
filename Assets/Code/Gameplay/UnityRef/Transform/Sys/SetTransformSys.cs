using Gameplay.UnityRef.Transform.Comp;
using Gameplay.UnityRef.Transform.Extensions;
using Leopotam.EcsLite;

namespace Gameplay.UnityRef.Transform.Sys {
   public class SetTransformSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<EcsTransform>  _ecs;
      private EcsPool<URefTransform> _uRef;


      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<EcsTransform>().Inc<URefTransform>().End();

         _ecs  = _world.GetPool<EcsTransform>();
         _uRef = _world.GetPool<URefTransform>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            _uRef.Get(e).Component.Sync(_ecs.Get(e));
         }
      }
   }
}