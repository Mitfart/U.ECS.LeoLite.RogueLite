using Engine.Ecs;
using Gameplay.HitBoxes.Debug;
using Gameplay.HitBoxes.Sys;

namespace Gameplay.HitBoxes {
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