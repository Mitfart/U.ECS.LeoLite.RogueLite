using Battle.HitBoxes.Debug;
using Battle.HitBoxes.Sys;
using Battle.UI;
using Engine.Ecs;

namespace Battle {
  public class BattleSystems : EcsSystemsPack {
    protected override void RegisterSystems() {
      Add<CreateHitEventSys>();
#if UNITY_EDITOR
      Add<HitBoxDebugSys>();
      Add<HitEventDebugSys>();
#endif
      Add<InvincibilityAfterHitEventSys>();
      Add<TakeDamageByHitEventSys>();
      Add<SetHealthUISys>();
    }
  }
}