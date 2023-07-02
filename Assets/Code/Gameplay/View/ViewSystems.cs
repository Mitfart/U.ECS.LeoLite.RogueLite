using Engine.Ecs;
using Gameplay.View.Sys;

namespace Gameplay.View {
   public class ViewSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<DestroyViewSys>();
         Add<RefreshViewSys>();
      }
   }
}