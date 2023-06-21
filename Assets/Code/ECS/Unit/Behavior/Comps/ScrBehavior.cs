using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Behavior.ECS {
  public abstract class ScrBehavior : ScrComponent<Behavior> {
    public override Behavior GetComponent() => new(GetBehaviorTree());

    protected abstract BehaviorTree GetBehaviorTree();
  }
}