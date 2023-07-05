using Gameplay.Unit.Behavior.Nodes;
using Infrastructure.Services.Time;
using Leopotam.EcsLite;

namespace Gameplay.Unit.Behavior {
   public sealed class BehaviorTree {
      public BehaviorState State { get; private set; } = BehaviorState.Run;
      public BehaviorNode  Entry { get; }

      public bool Initialized { get; private set; }


      private int          _entity;
      private EcsWorld     _world;
      private ITimeService _timeService;



      public BehaviorTree(BehaviorNode entry) {
         Entry = entry;
      }

      public void Init(int entity, EcsWorld world, ITimeService timeService) {
         Initialized = true;

         _entity      = entity;
         _world       = world;
         _timeService = timeService;

         Entry.Init(_entity, _world, _timeService);
      }


      public BehaviorState Run()
         => State == BehaviorState.Run
            ? State = Entry.Run()
            : State;
   }
}