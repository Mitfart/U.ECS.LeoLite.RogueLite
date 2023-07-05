using System;
using Infrastructure.Services.Time;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using VContainer;

namespace Gameplay.Unit.Behavior.Comps {
   public class BehaviorProv : EcsScrProvider<Behavior, ScrBehavior> {
      private ITimeService _timeService;

      [Inject]
      public void Construct(ITimeService timeService) {
         _timeService = timeService;
      }
      
      protected override void Add(EcsPool<Behavior> pool, int e, EcsWorld world) {
         base.Add(pool, e, world);

         pool.Get(e).Tree.Init(e, world, _timeService);
      }
   }

   [Serializable]
   public struct Behavior {
      public BehaviorTree Tree;
   }
}