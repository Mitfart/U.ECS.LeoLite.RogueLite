using _Lab;
using Extensions.Ecs;
using Gameplay.Player.Sys;

namespace Gameplay.Player {
   public class PlayerSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<MovementInputSys>();
         
         Add<TestPlayerInputSys>();
         Add<PlayerPathMoveToCursor>();
      }
   }
}