using Engine.Ecs;
using HitBoxes.Debug;

namespace HitBoxes {
   public class BattleSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<CreateHitEventSys>();
         Add<InvincibilityAfterHitEventSys>();

#if UNITY_EDITOR
         Add<HitBoxDebugSys>();
         Add<HitEventDebugSys>();
#endif
      }
   }
}