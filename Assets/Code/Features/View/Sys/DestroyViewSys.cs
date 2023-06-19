using Leopotam.EcsLite;

namespace Features.View {
  public class DestroyViewSys : IEcsRunSystem, IEcsInitSystem {
    private EcsWorld  _world;
    private EcsFilter _filter;

    private EcsPool<View> _viewPool;

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world
               .Filter<View>()
               .Inc<Destroy.Destroy>()
               .End();

      _viewPool = _world.GetPool<View>();
    }


    public void Run(IEcsSystems systems) {
      foreach (int e in _filter)
        _viewPool.Get(e).value.Destroy();
    }
  }
}