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
      private IAINavService _navService;

      private EcsPool<EcsTransform> _ecsTransformPool;
      private EcsPool<Path>         _pathPool;



      protected override void OnInit() {
         _ecsTransformPool = World.GetPool<EcsTransform>();
         _pathPool         = World.GetPool<Path>();

         _navService = Di.Resolve<IAINavService>();
      }

      protected override BehaviorState OnRun() {
         Vector3 destination = Destination();

         if (!PathExist(destination))
            return BehaviorState.Fail;

         return AtDestination()
            ? BehaviorState.Success
            : BehaviorState.Run;
      }


      protected bool PathExist(Vector3 destination)
         => _navService
           .CalcPath(
               Position(Entity),
               destination,
               Path().Value
            );



      protected abstract Vector3 Destination();

      protected     bool    AtDestination()      => Vector3.Distance(Position(Entity), Path().NextCorner()) <= Consts.EPSILON;
      protected     Vector3 Position(int entity) => _ecsTransformPool.Get(entity).Position;
      protected ref Path    Path()               => ref _pathPool.GetOrAdd(Entity);
   }
}