using Engine.Ecs;

namespace Movement {
  public class MovementSystems : EcsSystemsPack {
    protected override void RegisterSystems() {
      Add<DirectionInputSys>();

      Add<TransformMovementSys>();
      Add<PhysicsMovementSys>();
    }
  }
}