using Engine.Ecs;
using Leopotam.EcsLite;
using Physics;
using UnityEngine;
using UnityRef;

namespace Movement {
  public class PhysicsMovementSys : IEcsFixedRunSystem, IEcsInitSystem {
    private EcsWorld  _world;
    private EcsFilter _filter;

    private EcsPool<Rigidbody2DRef>  _rigidbodyLinkPool;
    private EcsPool<MoveDirection>   _moveDirectionPool;
    private EcsPool<Speed>           _speedPool;
    private EcsPool<PhysicsMovement> _movementPool;


    public void FixedRun(IEcsSystems systems) {
      float delta        = Time.fixedDeltaTime;
      float dividedDelta = 1f / delta;


      foreach (int e in _filter) {
        Rigidbody2D         rb         = _rigidbodyLinkPool.Get(e).Component;
        Vector2             input      = _moveDirectionPool.Get(e).value;
        float               speed      = _speedPool.Get(e).value;
        ref PhysicsMovement parameters = ref _movementPool.Get(e);

        Vector2 curVel    = rb.velocity;
        Vector2 targetVel = input * speed;


        float velDot   = Vector2.Dot(input, curVel.normalized);
        float accel    = parameters.Accel    * parameters.AccelDotFactor.Evaluate(velDot);
        float maxAccel = parameters.MaxAccel * parameters.MaxAccelDotFactor.Evaluate(velDot);

        var nextVel = Vector2.MoveTowards(curVel, targetVel, accel * delta);


        Vector2 requiredAccel = (nextVel - curVel) * dividedDelta;

        requiredAccel = Vector2.ClampMagnitude(requiredAccel, maxAccel);

        rb.AddForce(requiredAccel);
      }
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world.Filter<MoveDirection>()
                      .Inc<Rigidbody2DRef>()
                      .Inc<PhysicsMovement>()
                      .End();

      _rigidbodyLinkPool = _world.GetPool<Rigidbody2DRef>();
      _moveDirectionPool = _world.GetPool<MoveDirection>();

      _speedPool    = _world.GetPool<Speed>();
      _movementPool = _world.GetPool<PhysicsMovement>();
    }
  }
}