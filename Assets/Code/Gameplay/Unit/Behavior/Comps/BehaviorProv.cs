using System;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Gameplay.Unit.Behavior.Comps {
   public class BehaviorProv : EcsScrProvider<Behavior, ScrBehavior> { }

   [Serializable]
   public struct Behavior {
      public BehaviorTree Tree;

      public Behavior(BehaviorTree behaviorTree) {
         Tree = behaviorTree;
      }
   }
}