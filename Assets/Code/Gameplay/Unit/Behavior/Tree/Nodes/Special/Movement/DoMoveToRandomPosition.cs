using Gameplay.Movement.Comps;
using Gameplay.Unit.Behavior.Comps;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Unit.Behavior.Nodes.Special.Movement {
   public class DoMoveToRandomPosition : BehaviorNode {
      private const float _EPSILON = .0001f;

      private EcsPool<ViewRadius>    _viewRadiusPool;
      private EcsPool<EcsTransform>  _ecsTransformPool;
      private EcsPool<MoveDirection> _moveDirectionPool;

      private Vector3 _destination;



      protected override void OnInit() {
         _viewRadiusPool    = World.GetPool<ViewRadius>();
         _ecsTransformPool  = World.GetPool<EcsTransform>();
         _moveDirectionPool = World.GetPool<MoveDirection>();
      }

      protected override void OnBegin() {
         _destination = RandomPosition();
      }

      protected override BehaviorState OnRun() {
         Vector3 deltaPos = DeltaPos();

         if (AtDestination(deltaPos))
            return base.OnRun();

         SetMoveDir(deltaPos);
         return BehaviorState.Run;
      }

      protected override void OnFinish() {
         SetMoveDir(Vector3.zero);
      }



      private static bool AtDestination(Vector3 deltaPos) => deltaPos.sqrMagnitude <= _EPSILON;

      private void SetMoveDir(Vector3 dir) => _moveDirectionPool.Get(Entity).value = dir.normalized;

      private Vector3 DeltaPos()               => _destination             - Position();
      private Vector3 RandomPosition()         => RelativeRandomPosition() + Position();
      private Vector3 RelativeRandomPosition() => (Vector3)Random.insideUnitCircle * ViewRadius();

      private Vector3 Position()   => _ecsTransformPool.Get(Entity).Position;
      private float   ViewRadius() => _viewRadiusPool.Get(Entity).value;
   }
}