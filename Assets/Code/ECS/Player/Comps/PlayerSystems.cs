using _Lab;
using ECS.Player.Sys;
using Engine.Ecs;

namespace ECS.Player.Comps {
   public class PlayerSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<PlayerInputSys>();
         Add<TestPlayerInputSys>();
      }
   }
}