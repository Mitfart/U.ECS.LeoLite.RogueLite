using Engine.Ecs;

namespace UnityRef {
  public class SetUnityDataSystems : EcsSystemsPack {
    protected override void RegisterSystems() {
      Add<SetTransformSys>();
    }
  }
}