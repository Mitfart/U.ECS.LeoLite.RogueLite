using Extensions.Ecs;
using Gameplay.Level.ecs.tmp.Sys;

namespace Gameplay.Level.ecs.tmp {
   public class LevelSystems : EcsSystemsPack {
      protected override void RegisterSystems() => Add<InteractWithDoorSys>();
   }
}