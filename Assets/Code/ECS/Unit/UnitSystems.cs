using ECS.Unit.Behavior.Comps;
using ECS.Unit.Sys;
using Engine.Ecs;

namespace ECS.Unit {
   public class UnitSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<TakeDamageByHitEventSys>();
         Add<ProcessBehaviorSys>();
      }
   }
}