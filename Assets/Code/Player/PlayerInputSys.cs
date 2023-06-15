using Leopotam.EcsLite;
using Movement;
using UnityEngine;

namespace Player {
  public class PlayerInputSys : IEcsRunSystem, IEcsInitSystem {
    private readonly Controls  _controls;
    private          EcsWorld  _world;
    private          EcsFilter _filter;

    private EcsPool<MoveDirection> _moveDirectionPool;


    
    public PlayerInputSys(Controls controls) {
      _controls = controls;
    }

    public void Run(IEcsSystems systems) {
      var input = _controls.Game.Move.ReadValue<Vector2>();
      
      foreach (int e in _filter)
        _moveDirectionPool.Get(e).value = input;
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