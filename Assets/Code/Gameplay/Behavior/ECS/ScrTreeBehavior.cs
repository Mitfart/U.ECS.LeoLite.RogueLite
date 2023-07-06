using Gameplay.Unit.Behavior.ECS.Comps;
using Gameplay.Unit.Behavior.Tree;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Gameplay.Unit.Behavior.ECS {
   public abstract class ScrTreeBehavior : ScrComponent<AI> {
      public override AI Get() => new() { Behavior = GetBehaviorTree() };

      protected abstract BehaviorTree GetBehaviorTree();
   }
}