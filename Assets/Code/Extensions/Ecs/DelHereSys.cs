using Leopotam.EcsLite;

namespace Extensions.Ecs {
  public sealed class DelHereSys<T> : IEcsRunSystem, IEcsInitSystem where T : struct {
    private EcsFilter  _filter;
    private EcsPool<T> _tPool;
    private EcsWorld   _world;

    public void Init(IEcsSystems systems) {
      _world  = systems.GetWorld();
      _filter = _world.Filter<T>().End();
      _tPool  = _world.GetPool<T>();
    }

    public void Run(IEcsSystems systems) {
      foreach (int e in _filter)
        _tPool.Del(e);
    }
  }
}