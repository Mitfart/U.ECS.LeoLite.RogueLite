using Extensions;
using Extensions.Ecs;
using Gameplay.Unit.Behavior.ECS.Comps;
using Gameplay.Unit.Behavior.Tree.Nodes;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;
using VContainer;

namespace Gameplay.Unit.Behavior.Nodes.Movement {
   public abstract class DoMoveToNode : BehaviorNode {
      protected IAINavService NavService;

      private EcsPool<EcsTransform> _ecsTransformPool;
      private EcsPool<Path>         _pathPool;



      protected override void OnInit() {
         _ecsTransformPool = World.GetPool<EcsTransform>();
         _pathPool         = World.GetPool<Path>();

         NavService = Di.Resolve<IAINavService>();
      }

      protected override BehaviorState OnRun() {
         Vector3 destination = Destination();

         if (!MoveTo(destination))
            return BehaviorState.Fail;

         return AtTarget(destination)
            ? BehaviorState.Success
            : BehaviorState.Run;
      }

      protected bool MoveTo(Vector3 destination)
         => _pathPool
           .Set(Entity)
           .Calc(
               NavService,
               Position(Entity),
               destination
            );

      protected abstract Vector3 Destination();

      protected Vector3 Position(int     entity)      => _ecsTransformPool.Get(entity).Position;
      protected bool    AtTarget(Vector3 destination) => Vector3.Distance(Position(Entity), destination) <= Consts.EPSILON;
   }
}