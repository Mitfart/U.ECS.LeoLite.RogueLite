using ECS.Unit.Behavior.Comps;
using ECS.Unit.Behavior.Nodes.Special;
using ECS.Unit.Behavior.Nodes.Special.Movement;
using ECS.Unit.Behavior.Nodes.Structural;
using UnityEngine;

namespace ECS.Unit.Behavior.Concrete {
   [CreateAssetMenu]
   public class TestBehavior : ScrBehavior {
      [SerializeField] [Min(0f)] private float waitTime = .25f;


      protected override BehaviorTree GetBehaviorTree() {
         return new(new DoRepeat(new IfTargetPlayer(new DoMoveToTarget(), new DoWait(waitTime, new DoMoveToRandomPosition()))));
      }
   }
}