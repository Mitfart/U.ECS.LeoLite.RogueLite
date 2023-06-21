using Behavior.Nodes.Structural;
using ECS.Unit.Comps;
using Extensions.Ecs;
using Features.Player;
using Leopotam.EcsLite;
using UnityEngine;
using UnityRef;

namespace Behavior.Nodes.Special.Movement {
  public class IfTargetPlayer : ConditionNode {
    private EcsFilter _playerFilter;

    private EcsPool<Target>       _targetPool;
    private EcsPool<ViewRadius>   _viewRadiusPool;
    private EcsPool<EcsTransform> _ecsTransformPool;



    protected override void OnBegin(int e, EcsWorld world) {
      _playerFilter = world
                     .Filter<PlayerTag>()
                     .Inc<EcsTransform>()
                     .End();

      _targetPool       = world.GetPool<Target>();
      _viewRadiusPool   = world.GetPool<ViewRadius>();
      _ecsTransformPool = world.GetPool<EcsTransform>();
    }

    protected override bool Condition(int e, EcsWorld world) {
      if (!FindClosestPlayer(e, out int closestPlayerE))
        return false;

      ref Target target = ref _targetPool.Get(e);
      target.target = world.PackEntityWithWorld(closestPlayerE);
      return true;
    }



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

    private float   ViewRadius(int     e) => _viewRadiusPool.TryGet(e, out ViewRadius viewRadius) ? viewRadius.value : float.MaxValue;
    private Vector3 Position(int       e) => _ecsTransformPool.Get(e).Position;
    public IfTargetPlayer(BehaviorNode @true, BehaviorNode @false) : base(@true, @false) { }
  }
}