using Engine.Ecs;
using Gameplay.Movement.Smooth;
using Gameplay.Movement.Sys;

namespace Gameplay.Movement {
   public class MovementSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<DirectionInputSys>();

         Add<TransformMovementSys>();
         Add<PhysicsMovementSys>();

         Add<SmoothTransformSys>();
      }
   }
}