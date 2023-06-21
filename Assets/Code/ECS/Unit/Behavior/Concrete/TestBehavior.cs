using UnityEngine;
using Behavior.ECS;
using Behavior.Nodes.Special.Movement;
using Behavior.Nodes.Structural;

namespace Behavior.Concrete {
  [CreateAssetMenu]
  public class TestBehavior : ScrBehavior {
    [SerializeField][Min(0f)] private float waitTime = .25f;


    protected override BehaviorTree GetBehaviorTree()
      => new(
        new DoRepeat(
          new IfTargetPlayer(
            @true: new DoMoveToTarget(),
            @false: new DoWait(
              waitTime,
              new DoMoveToRandomPosition()
            )
          )
        )
      );
  }
}