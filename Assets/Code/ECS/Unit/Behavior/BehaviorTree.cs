﻿using Behavior.Nodes;
using Leopotam.EcsLite;

namespace Behavior {
  public class BehaviorTree {
    public BehaviorState State { get; private set; } = BehaviorState.Run;
    public BehaviorNode    Entry { get; }



    public BehaviorTree(BehaviorNode entry) {
      Entry = entry;
    }

    public BehaviorState Run(int e, EcsWorld world)
      => State == BehaviorState.Run
        ? State = Entry.Run(e, world)
        : State;
  }
}