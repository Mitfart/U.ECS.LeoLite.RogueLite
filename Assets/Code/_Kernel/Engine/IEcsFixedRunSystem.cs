using Leopotam.EcsLite;

namespace Engine {
   public interface IEcsFixedRunSystem {
      void FixedRun(IEcsSystems systems);
   }
}