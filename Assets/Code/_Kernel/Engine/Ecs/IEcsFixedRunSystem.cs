using Leopotam.EcsLite;

namespace Engine.Ecs {
  public interface IEcsFixedRunSystem {
    void FixedRun(IEcsSystems systems);
  }
}