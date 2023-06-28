using ECS.Battle.Debug;
using Engine.Ecs;

namespace ECS.Battle {
   public class BattleSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<CreateHitEventSys>();
         Add<InvincibilityAfterHitEventSys>();
         Add<PenetrationSys>();

#if UNITY_EDITOR
         Add<HitBoxDebugSys>();
         Add<HitEventDebugSys>();
#endif
      }
   }
}