using _Lab;
using Engine.Ecs;
using Player.Sys;

namespace Player {
   public class PlayerSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<PlayerInputSys>();
         Add<TestPlayerInputSys>();
      }
   }
}