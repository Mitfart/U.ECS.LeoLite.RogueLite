using Unit.Behavior.Comps;
using Unit.Behavior.Nodes.Special;
using Unit.Behavior.Nodes.Special.Movement;
using Unit.Behavior.Nodes.Structural;
using UnityEngine;

namespace Unit.Behavior.Concrete {
   [CreateAssetMenu]
   public class TestBehavior : ScrBehavior {
      [SerializeField, Min(min: 0f)]  private float waitTime = .25f;


      protected override BehaviorTree GetBehaviorTree() => new BehaviorTree(new DoRepeat(new IfTargetPlayer(new DoMoveToTarget(), new DoWait(waitTime, new DoMoveToRandomPosition()))));
   }
}