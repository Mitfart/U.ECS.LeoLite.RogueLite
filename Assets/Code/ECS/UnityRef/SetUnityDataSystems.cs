using Engine.Ecs;

namespace ECS.UnityRef {
   public class SetUnityDataSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<SetTransformSys>();
      }
   }
}