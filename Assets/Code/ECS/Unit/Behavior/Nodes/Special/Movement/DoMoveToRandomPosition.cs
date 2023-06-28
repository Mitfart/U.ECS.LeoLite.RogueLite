using ECS.Movement;
using ECS.Unit.Behavior.Comps;
using ECS.UnityRef;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Unit.Behavior.Nodes.Special.Movement {
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



      private static bool AtDestination(Vector3 deltaPos) {
         return deltaPos.magnitude <= _EPSILON;
      }

      private void SetMoveDir(int e, Vector3 dir) {
         _moveDirectionPool.Get(e).value = dir.normalized;
      }

      private Vector3 DeltaPos(int e) {
         return _destination - Position(e);
      }

      private Vector3 RelativeRandomPosition(int e) {
         return RandomPosition(e) + Position(e);
      }

      private Vector3 Position(int e) {
         return _ecsTransformPool.Get(e).Position;
      }

      private Vector3 RandomPosition(int e) {
         return (Vector3)Random.insideUnitCircle * _viewRadiusPool.Get(e).value;
      }
   }
}