﻿namespace Gameplay.Unit.Behavior.Nodes.Structural {
   public class DoRepeat : BehaviorNode {
      public DoRepeat(params BehaviorNode[] childNodes) : base(childNodes) { }

      protected override BehaviorState OnRun() {
         base.OnRun();
         return BehaviorState.Run;
      }
   }
}