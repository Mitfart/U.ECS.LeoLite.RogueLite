using Engine.Ecs;
using Extentions;

namespace UnityRef {
  public class GetUnityDataSystems : EcsSystemsPack {
    protected override void RegisterSystems() {
      Add<GetTransformSys>();
    }
  }
}