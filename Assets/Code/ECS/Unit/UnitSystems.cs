using Behavior.ECS;
using Engine.Ecs;
using Features.Battle;

namespace Features.Unit {
  public class UnitSystems : EcsSystemsPack {
    protected override void RegisterSystems() {
      Add<TakeDamageByHitEventSys>();
      Add<ProcessBehaviorSys>();
    }
  }
}