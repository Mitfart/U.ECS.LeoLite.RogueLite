using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Unit.Behavior.Comps {
   public abstract class ScrBehavior : ScrComponent<Behavior> {
      public override Behavior GetComponent() => new Behavior(GetBehaviorTree());

      protected abstract BehaviorTree GetBehaviorTree();
   }
}