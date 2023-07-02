using Engine.Ecs;

namespace UnityRef {
   public class GetUnityDataSystems : EcsSystemsPack {
      protected override void RegisterSystems() => Add<GetTransformSys>();
   }
}