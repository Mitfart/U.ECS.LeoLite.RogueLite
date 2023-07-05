using Extensions.Ecs;
using Gameplay.Player.Comps;
using Gameplay.Unit.Behavior.Comps;
using Gameplay.Unit.Behavior.Nodes.Structural;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Unit.Behavior.Nodes.Special {
   public class IfTargetPlayer : ConditionNode {
      private EcsFilter _playerFilter;

      private EcsPool<Target>       _targetPool;
      private EcsPool<ViewRadius>   _viewRadiusPool;
      private EcsPool<EcsTransform> _ecsTransformPool;
      public IfTargetPlayer(BehaviorNode @true, BehaviorNode @false) : base(@true, @false) { }



      protected override void OnInit() {
         _playerFilter = World.Filter<PlayerTag>().Inc<EcsTransform>().End();

         _targetPool       = World.GetPool<Target>();
         _viewRadiusPool   = World.GetPool<ViewRadius>();
         _ecsTransformPool = World.GetPool<EcsTransform>();
      }

      protected override bool Condition() {
         if (!FindClosestPlayer(Entity, out int closestPlayerE))
            return false;

         SetTarget(closestPlayerE);
         return true;
      }



      private void SetTarget(int closestPlayerE) => _targetPool.Get(Entity).Value = World.PackEntityWithWorld(closestPlayerE);

      private bool FindClosestPlayer(int e, out int closestPlayerE) {
         float minDistance = ViewRadius(e);

         closestPlayerE = -1;


         foreach (int playerE in _playerFilter) {
            Vector3 curPosition = Position(playerE);
            float   curDistance = Vector2.Distance(Position(e), curPosition);

            if (curDistance >= minDistance)
               continue;

            closestPlayerE = playerE;
            minDistance    = curDistance;
         }

         return closestPlayerE >= 0;
      }

      private float   ViewRadius(int e) => _viewRadiusPool.TryGet(e, out ViewRadius viewRadius) ? viewRadius.value : float.MaxValue;
      private Vector3 Position(int   e) => _ecsTransformPool.Get(e).Position;
   }
}