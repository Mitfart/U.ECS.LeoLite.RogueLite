using Engine.Ecs;
using Unit.Behavior.Comps;
using Unit.Comps;
using Unit.Sys;

namespace Unit {
   public class UnitSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<PenetrationSys>();
         Add<TakeDamageByHitEventSys>();
         Add<ProcessBehaviorSys>();
      }
   }
}