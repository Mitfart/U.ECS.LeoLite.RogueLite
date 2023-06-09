using Extentions;
using Leopotam.EcsLite;
using UnityEngine;
using UnityRef;

namespace Movement {
  public class TransformMovementSys : IEcsRunSystem, IEcsInitSystem {
    private EcsWorld  _world;
    private EcsFilter _filter;

    private EcsPool<EcsTransform>  _transformPool;
    private EcsPool<MoveDirection> _moveDirectionPool;
    private EcsPool<Speed>         _speedPool;



    public void Run(IEcsSystems systems) {
      float delta = Time.deltaTime;

      foreach (int e in _filter) {
        ref EcsTransform  transform     = ref _transformPool.Get(e);
        ref MoveDirection moveDirection = ref _moveDirectionPool.Get(e);

        float speed = _speedPool.TryGet(e, out Speed ms) ? ms.value : 1f;

        transform.position += moveDirection.value * (speed * delta);
      }
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world.Filter<EcsTransform>()
                      .Inc<MoveDirection>()
                      .Exc<Rigidbody2DRef>()
                      .End();

      _transformPool     = _world.GetPool<EcsTransform>();
      _moveDirectionPool = _world.GetPool<MoveDirection>();

      _speedPool = _world.GetPool<Speed>();
    }
  }
}