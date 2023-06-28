using ECS.Movement;
using ECS.Unit.Behavior.Comps;
using ECS.UnityRef;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Unit.Behavior.Nodes.Special.Movement {
   public class DoMoveToTarget : BehaviorNode {
      private EcsPool<Target>        _targetPool;
      private EcsPool<EcsTransform>  _ecsTransformPool;
      private EcsPool<MoveDirection> _moveDirectionPool;



      protected override void OnBegin(int e, EcsWorld world) {
         _targetPool        = world.GetPool<Target>();
         _ecsTransformPool  = world.GetPool<EcsTransform>();
         _moveDirectionPool = world.GetPool<MoveDirection>();
      }

      protected override BehaviorState OnRun(int e, EcsWorld world) {
         if (HasTarget(e, out int targetE)) SetMoveDir(e, Position(targetE) - Position(e));

         return BehaviorState.Run;
      }



      private void SetMoveDir(int e, Vector3 dir) {
         _moveDirectionPool.Get(e).value = dir.normalized;
      }

      private Vector3 Position(int e) {
         return _ecsTransformPool.Get(e).Position;
      }

      private bool HasTarget(int e, out int targetE) {
         return _targetPool.Get(e).Value.Unpack(out EcsWorld _, out targetE);
      }
   }
}