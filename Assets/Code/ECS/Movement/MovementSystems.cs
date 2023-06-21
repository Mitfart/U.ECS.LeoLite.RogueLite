using Engine.Ecs;
using Features.Movement.Smooth;

namespace Features.Movement {
  public class MovementSystems : EcsSystemsPack {
    protected override void RegisterSystems() {
      Add<DirectionInputSys>();

      Add<TransformMovementSys>();
      Add<PhysicsMovementSys>();

      Add<SmoothTransformSys>();
    }
  }
}