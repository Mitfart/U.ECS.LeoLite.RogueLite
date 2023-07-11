using Extensions.Ecs;
using Gameplay.Unit.Behavior.ECS.Debug;
using Gameplay.Unit.Behavior.ECS.Sys;

namespace Gameplay.Unit.Behavior {
   public class BehaviorSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<ProcessBehaviorSys>();
         
         Add<ProcessPathSys>();
         Add<MoveByPathSys>();

#if UNITY_EDITOR
         Add<DebugPathSys>();
#endif
      }
   }
}