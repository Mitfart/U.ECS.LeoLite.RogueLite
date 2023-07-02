using Gameplay.Movement.Comps;
using Gameplay.Unit.Behavior.Comps;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Unit.Behavior.Nodes.Special.Movement {
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
         if (HasTarget(e, out int targetE))
            SetMoveDir(e, Position(targetE) - Position(e));

         return BehaviorState.Run;
      }



      private void SetMoveDir(int e, Vector3 dir) => _moveDirectionPool.Get(e).value = dir.normalized;

      private Vector3 Position(int e) => _ecsTransformPool.Get(e).Position;

      private bool HasTarget(int e, out int targetE) => _targetPool.Get(e).Value.Unpack(out EcsWorld _, out targetE);
   }
}