using Engine.Ecs;
using Movement;

namespace Player {
  public class PlayerSystems : EcsSystemsPack {
    protected override void RegisterSystems() {
      Add<PlayerInputSys>();
    }
  }
}