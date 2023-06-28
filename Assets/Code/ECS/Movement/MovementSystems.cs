using ECS.Movement.Smooth;
using Engine.Ecs;

namespace ECS.Movement {
   public class MovementSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<DirectionInputSys>();

         Add<TransformMovementSys>();
         Add<PhysicsMovementSys>();

         Add<SmoothTransformSys>();
      }
   }
}