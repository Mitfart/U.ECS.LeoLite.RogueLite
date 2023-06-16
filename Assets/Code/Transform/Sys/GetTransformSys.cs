using Extentions;
using Leopotam.EcsLite;

public class GetTransformSys : IEcsRunSystem, IEcsInitSystem {
  private EcsWorld  _world;
  private EcsFilter _filter;

  private EcsPool<URefTransform> _uRef;
  private EcsPool<EcsTransform>  _ecs;


  public void Init(IEcsSystems systems) {
    _world  = systems.GetWorld();
    _filter = _world.Filter<EcsTransform>().Inc<URefTransform>().End();

    _ecs  = _world.GetPool<EcsTransform>();
    _uRef = _world.GetPool<URefTransform>();
  }

  public void Run(IEcsSystems systems) {
    foreach (int e in _filter)
      _ecs.Get(e).Sync(_uRef.Get(e).Component);
  }
}