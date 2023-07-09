using Gameplay.Movement.Comps;
using Gameplay.Movement.Direction.Extensions;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;

namespace Gameplay.Movement.Sys {
   public class DirectionInputSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<DirectionInput> _directionInputPool;
      private EcsPool<EcsTransform>   _displacementPool;
      private EcsPool<MoveTo>         _moveDirectionPool;



      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<DirectionInput>()
                         .Inc<MoveTo>()
                         .Inc<EcsTransform>()
                         .End();

         _moveDirectionPool  = _world.GetPool<MoveTo>();
         _directionInputPool = _world.GetPool<DirectionInput>();
         _displacementPool   = _world.GetPool<EcsTransform>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            ref MoveTo         moveTo         = ref _moveDirectionPool.Get(e);
            ref DirectionInput directionInput = ref _directionInputPool.Get(e);
            ref EcsTransform   transform      = ref _displacementPool.Get(e);

            moveTo.position = transform.Position + transform.GetDirection(directionInput.value);
         }
      }
   }
}