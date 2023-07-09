using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Movement.Smooth {
   public class SmoothTransformSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<EcsTransform>    _transformPool;
      private EcsPool<SmoothTransform> _smoothPool;


      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<EcsTransform>()
                         .Inc<SmoothTransform>()
                         .End();

         _transformPool = _world.GetPool<EcsTransform>();
         _smoothPool    = _world.GetPool<SmoothTransform>();

         InitEntities();
      }

      public void Run(IEcsSystems systems) {
         float delta = Time.deltaTime;

         foreach (int e in _filter) {
            ref EcsTransform transform = ref _transformPool.Get(e);
            SmoothVector3    smooth    = _smoothPool.Get(e).value;

            transform.Position = smooth.Update(delta, transform.Position);
         }
      }

      private void InitEntities() {
         foreach (int e in _filter) {
            _smoothPool.Get(e).value.Init(_transformPool.Get(e).Position);
         }
      }
   }
}