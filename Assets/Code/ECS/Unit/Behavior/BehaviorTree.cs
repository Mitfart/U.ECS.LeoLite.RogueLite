﻿using ECS.Unit.Behavior.Nodes;
using Leopotam.EcsLite;

namespace ECS.Unit.Behavior {
   public class BehaviorTree {
      public BehaviorState State { get; private set; } = BehaviorState.Run;
      public BehaviorNode  Entry { get; }



      public BehaviorTree(BehaviorNode entry) {
         Entry = entry;
      }

      public BehaviorState Run(int e, EcsWorld world) {
         return State == BehaviorState.Run ? State = Entry.Run(e, world) : State;
      }
   }
}