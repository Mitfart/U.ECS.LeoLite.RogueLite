using Extensions;
using Extensions.Ecs;
using Gameplay.Unit.Behavior.ECS.Comps;
using Gameplay.Unit.Behavior.Tree.Nodes;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

namespace Gameplay.Unit.Behavior.Nodes.Movement {
   public abstract class DoMoveToNode : BehaviorNode {
      private IAINavService _navService;

      private EcsPool<EcsTransform> _ecsTransformPool;
      private EcsPool<Path>         _pathPool;

      private NavMeshPath _path;



      protected override void OnInit() {
         _ecsTransformPool = World.GetPool<EcsTransform>();
         _pathPool         = World.GetPool<Path>();

         _navService = Di.Resolve<IAINavService>();
         _path      = _pathPool.Set(Entity).Value;
      }

      protected override BehaviorState OnRun() {
         Vector3 destination = Destination();

         if (!PathExist(destination))
            return BehaviorState.Fail;

         return AtTarget(destination)
            ? BehaviorState.Success
            : BehaviorState.Run;
      }

      protected bool PathExist(Vector3 destination)
         => _navService
           .CalcPath(
               Position(Entity),
               destination,
               _path
            );



      protected abstract Vector3 Destination();

      protected Vector3 Position(int entity) => _ecsTransformPool.Get(entity).Position;

      private bool AtTarget(Vector3 destination) => Vector3.Distance(Position(Entity), destination) <= Consts.EPSILON;
   }
}