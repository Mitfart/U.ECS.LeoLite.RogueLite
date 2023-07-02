using Leopotam.EcsLite;

namespace Gameplay.View.Comps {
   public interface IEcsView {
      void Refresh(EcsWorld         world, int entity);
      void OnDestroyEntity(EcsWorld world, int entity);
   }
}