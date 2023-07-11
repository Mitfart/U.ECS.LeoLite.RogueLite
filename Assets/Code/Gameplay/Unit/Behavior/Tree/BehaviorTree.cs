using Gameplay.Unit.Behavior.Tree.Nodes;
using Leopotam.EcsLite;
using VContainer;

namespace Gameplay.Unit.Behavior.Tree {
   public sealed class BehaviorTree {
      private int           _entity;
      private EcsWorld      _world;
      public  BehaviorState State { get; private set; } = BehaviorState.Run;
      public  BehaviorNode  Entry { get; }

      public bool Initialized { get; private set; }



      public BehaviorTree(BehaviorNode entry) {
         Entry = entry;
      }

      public void Init(int entity, EcsWorld world, IObjectResolver di) {
         Initialized = true;

         _entity = entity;
         _world  = world;

         Entry.Init(_entity, _world, di);
      }


      public BehaviorState Run()
         => State == BehaviorState.Run
            ? State = Entry.Run()
            : State;
   }
}