using Extensions.Ecs;

namespace Gameplay.Destroy {
   public class DestroySystems : EcsSystemsPack {
      protected override void RegisterSystems() => Add<DestroySys>();
   }
}