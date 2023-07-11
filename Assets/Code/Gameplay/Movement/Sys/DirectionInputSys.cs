using Gameplay.Movement.Comps;
using Gameplay.Movement.Direction.Extensions;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;

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
            ref EcsTransform transform = ref _displacementPool.Get(e);

            MoveTo(e, transform.Position + MoveDirection(transform, e));
         }
      }



      private Vector3             MoveDirection(EcsTransform transform, int e) => transform.GetDirection(DirectionInput(e));
      private Direction.Direction DirectionInput(int         e)              => _directionInputPool.Get(e).value;
      private void                MoveTo(int                 e, Vector3 pos) => _moveDirectionPool.Get(e).position = pos;
   }
}