using Gameplay.Unit.Behavior.ECS.Comps;
using Gameplay.Unit.Behavior.Tree;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Gameplay.Unit.Behavior.Concrete {
   public abstract class ScrBehavior : ScrComponent<AI> {
      public override AI Get() {
         value.Behavior = GetBehaviorTree();
         return base.Get();
      }

      protected abstract BehaviorTree GetBehaviorTree();
   }
}