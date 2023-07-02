using Engine.Ecs;

namespace Destroy {
   public class DestroySystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<DestroySys>();
      }
   }
}