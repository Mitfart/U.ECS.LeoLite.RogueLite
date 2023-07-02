using Gameplay.View.Comps;
using Leopotam.EcsLite;

namespace Gameplay.View {
   public class TEST_DestroyView : EcsView {
      public override void Refresh(EcsWorld world, int entity) { }

      public override void OnDestroyEntity(EcsWorld world, int entity) => Destroy(gameObject);
   }
}