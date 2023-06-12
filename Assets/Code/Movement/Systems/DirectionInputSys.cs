using Leopotam.EcsLite;
using UnityRef;
using UnityRef.Transform.Extras.Direction;

namespace Movement {
  public class DirectionInputSys : IEcsRunSystem, IEcsInitSystem {
    private EcsWorld  _world;
    private EcsFilter _filter;

    private EcsPool<DirectionInput> _directionInputPool;
    private EcsPool<EcsTransform>   _displacementPool;
    private EcsPool<MoveDirection>  _moveDirectionPool;

    
    public void Run(IEcsSystems systems) {
      foreach (int e in _filter) {
        ref MoveDirection  moveDirection  = ref _moveDirectionPool.Get(e);
        ref DirectionInput directionInput = ref _directionInputPool.Get(e);
        ref EcsTransform   transform      = ref _displacementPool.Get(e);

        moveDirection.value = transform.GetDirection(directionInput.value);
      }
    }
    
    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world
               .Filter<DirectionInput>()
               .Inc<MoveDirection>()
               .Inc<EcsTransform>()
               .End();

      _moveDirectionPool  = _world.GetPool<MoveDirection>();
      _directionInputPool = _world.GetPool<DirectionInput>();
      _displacementPool   = _world.GetPool<EcsTransform>();
    }
  }
}