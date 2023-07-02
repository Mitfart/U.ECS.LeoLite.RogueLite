using Leopotam.EcsLite;
using Movement;
using Unit.Behavior.Comps;
using UnityEngine;
using UnityRef;

namespace Unit.Behavior.Nodes.Special.Movement {
   public class DoMoveToRandomPosition : BehaviorNode {
      private const float _EPSILON = .0001f;

      private EcsPool<ViewRadius>    _viewRadiusPool;
      private EcsPool<EcsTransform>  _ecsTransformPool;
      private EcsPool<MoveDirection> _moveDirectionPool;

      private Vector3 _destination;



      protected override void OnBegin(int e, EcsWorld world) {
         _viewRadiusPool    = world.GetPool<ViewRadius>();
         _ecsTransformPool  = world.GetPool<EcsTransform>();
         _moveDirectionPool = world.GetPool<MoveDirection>();

         _destination = RelativeRandomPosition(e);
      }

      protected override BehaviorState OnRun(int e, EcsWorld world) {
         Vector3 deltaPos = DeltaPos(e);

         if (AtDestination(deltaPos)) return base.OnRun(e, world);

         SetMoveDir(e, deltaPos);
         return BehaviorState.Run;
      }



      private static bool AtDestination(Vector3 deltaPos) => deltaPos.magnitude <= _EPSILON;

      private void SetMoveDir(int e, Vector3 dir) => _moveDirectionPool.Get(e).value = dir.normalized;

      private Vector3 DeltaPos(int e) => _destination - Position(e);

      private Vector3 RelativeRandomPosition(int e) => RandomPosition(e) + Position(e);

      private Vector3 Position(int e) => _ecsTransformPool.Get(e).Position;

      private Vector3 RandomPosition(int e) => (Vector3)Random.insideUnitCircle * _viewRadiusPool.Get(e).value;
   }
}