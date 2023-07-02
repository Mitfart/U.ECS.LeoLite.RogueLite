using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Gameplay.Unit.Behavior.Comps {
   public abstract class ScrBehavior : ScrComponent<Behavior> {
      public override Behavior Get() => new(GetBehaviorTree());

      protected abstract BehaviorTree GetBehaviorTree();
   }
}