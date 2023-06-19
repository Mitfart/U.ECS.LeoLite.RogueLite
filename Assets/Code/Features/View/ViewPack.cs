using Engine.Ecs;

namespace Features.View {
  public class ViewPack : EcsSystemsPack {
    protected override void RegisterSystems() {
      Add<DestroyViewSys>();
      Add<RefreshViewSys>();
    }
  }
}