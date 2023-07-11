using Extensions.Ecs;
using Gameplay.Movement.Sys;

namespace Gameplay.Movement {
   public class MovementSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<DirectionInputSys>();

         Add<TransformMovementSys>();
      }
   }
}