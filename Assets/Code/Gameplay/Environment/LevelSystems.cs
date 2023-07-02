using Engine.Ecs;
using Gameplay.Level.Sys;

namespace Gameplay.Level {
   public class LevelSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<InteractWithDoorSys>();
      }
   }
}