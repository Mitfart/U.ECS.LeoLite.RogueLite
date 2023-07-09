using Gameplay.Movement.Comps;
using Gameplay.UnityRef.Transform.Comp;
using Gameplay.UnityRef.Transform.Extensions;
using Infrastructure.Services.Time;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Movement.Sys {
   public class TransformMovementSys : IEcsRunSystem, IEcsInitSystem {
      private readonly ITimeService _timeService;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<EcsTransform> _transformPool;
      private EcsPool<MoveTo>       _moveDirectionPool;
      private EcsPool<Speed>        _speedPool;



      public TransformMovementSys(ITimeService timeService) {
         _timeService = timeService;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<EcsTransform>()
                         .Inc<MoveTo>()
                         .Inc<Speed>()
                         .End();

         _transformPool     = _world.GetPool<EcsTransform>();
         _moveDirectionPool = _world.GetPool<MoveTo>();
         _speedPool         = _world.GetPool<Speed>();
      }

      public void Run(IEcsSystems systems) {
         float delta = _timeService.Delta;

         foreach (int e in _filter)
            Transform(e)
              .MoveTo(
                  Target(e),
                  Speed(e) * delta
               );
      }



      private ref EcsTransform Transform(int e) => ref _transformPool.Get(e);
      private ref Vector3      Target(int    e) => ref _moveDirectionPool.Get(e).position;
      private ref float        Speed(int     e) => ref _speedPool.Get(e).value;
   }
}