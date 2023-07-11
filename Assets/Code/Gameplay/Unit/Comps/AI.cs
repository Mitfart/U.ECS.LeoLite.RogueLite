using System;
using Gameplay.Unit.Behavior.Tree;

namespace Gameplay.Unit.Behavior.ECS.Comps {
   [Serializable]
   public struct AI {
      public BehaviorTree Behavior;
   }
}