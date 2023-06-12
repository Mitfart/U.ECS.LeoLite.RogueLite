using Leopotam.EcsLite;
using Player;
using UnityEngine;

namespace Movement {
  public class PlayerInputSys : IEcsRunSystem, IEcsInitSystem {
    private readonly Controls  _controls;
    private          EcsWorld  _world;
    private          EcsFilter _filter;

    private EcsPool<MoveDirection> _moveDirectionPool;


    
    public PlayerInputSys(Controls controls) {
      _controls = controls;
    }

    public void Run(IEcsSystems systems) {
      foreach (int e in _filter)
        _moveDirectionPool.Get(e).value = _controls.Game.Move.ReadValue<Vector2>().normalized;
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world
               .Filter<PlayerTag>()
               .Inc<MoveDirection>()
               .End();

      _moveDirectionPool  = _world.GetPool<MoveDirection>();
    }
  }
}