using _Lab;
using Engine.Ecs;

namespace Features.Player {
  public class PlayerSystems : EcsSystemsPack {
    protected override void RegisterSystems() {
      Add<PlayerInputSys>();
      Add<TestPlayerInputSys>();
    }
  }
}