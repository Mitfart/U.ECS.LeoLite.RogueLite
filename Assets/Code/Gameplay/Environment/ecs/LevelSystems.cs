using Engine.Ecs;
using Gameplay.Environment.ecs.Sys;

namespace Gameplay.Environment.ecs {
   public class LevelSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<InteractWithDoorSys>();
      }
   }
}