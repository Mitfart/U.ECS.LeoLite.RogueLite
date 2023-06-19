using Extensions.EcsTransform;
using Leopotam.EcsLite;

namespace UnityRef {
  public class SetTransformSys : IEcsRunSystem, IEcsInitSystem {
    private EcsWorld  _world;
    private EcsFilter _filter;

    private EcsPool<EcsTransform>  _ecs;
    private EcsPool<URefTransform> _uRef;


    public void Init(IEcsSystems systems) {
      _world  = systems.GetWorld();
      _filter = _world.Filter<EcsTransform>().Inc<URefTransform>().End();

      _ecs  = _world.GetPool<EcsTransform>();
      _uRef = _world.GetPool<URefTransform>();
    }

    public void Run(IEcsSystems systems) {
      foreach (int e in _filter)
        _uRef.Get(e).Component.Sync(_ecs.Get(e));
    }
  }
}