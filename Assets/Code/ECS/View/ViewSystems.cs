using Engine.Ecs;

namespace Features.View {
  public class ViewSystems : EcsSystemsPack {
    protected override void RegisterSystems() {
      Add<DestroyViewSys>();
      Add<RefreshViewSys>();
    }
  }
}