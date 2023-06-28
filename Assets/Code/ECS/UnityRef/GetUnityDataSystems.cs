using Engine.Ecs;

namespace ECS.UnityRef {
   public class GetUnityDataSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<GetTransformSys>();
      }
   }
}