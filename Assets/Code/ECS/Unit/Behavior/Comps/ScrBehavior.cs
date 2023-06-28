using Mitfart.LeoECSLite.UniLeo.Providers;

namespace ECS.Unit.Behavior.Comps {
   public abstract class ScrBehavior : ScrComponent<Behavior> {
      public override Behavior GetComponent() {
         return new(GetBehaviorTree());
      }

      protected abstract BehaviorTree GetBehaviorTree();
   }
}