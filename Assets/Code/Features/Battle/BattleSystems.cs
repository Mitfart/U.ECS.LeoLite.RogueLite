using Engine.Ecs;
using Features.Battle.Debug;
using Features.Battle.HitBoxes.Sys;
using Features.Weapon.Projectiles;

namespace Features.Battle {
  public class BattleSystems : EcsSystemsPack {
    protected override void RegisterSystems() {
      Add<CreateHitEventSys>();
      Add<InvincibilityAfterHitEventSys>();
      Add<TakeDamageByHitEventSys>();
      Add<DestroyAfterHitsSys>();

#if UNITY_EDITOR
      Add<HitBoxDebugSys>();
      Add<HitEventDebugSys>();
#endif
    }
  }
}