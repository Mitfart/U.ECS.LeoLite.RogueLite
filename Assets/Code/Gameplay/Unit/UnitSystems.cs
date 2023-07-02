using Engine.Ecs;
using Gameplay.Unit.Behavior.Comps;
using Gameplay.Unit.Comps;
using Gameplay.Unit.Sys;

namespace Gameplay.Unit {
   public class UnitSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<PenetrationSys>();
         Add<TakeDamageByHitEventSys>();
         Add<ProcessBehaviorSys>();
      }
   }
}