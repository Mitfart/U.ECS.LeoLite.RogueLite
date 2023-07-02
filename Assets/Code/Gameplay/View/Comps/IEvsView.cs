using Leopotam.EcsLite;

namespace View {
   public interface IEvsView {
      void Refresh(EcsWorld         world, int entity);
      void OnDestroyEntity(EcsWorld world, int entity);
   }
}