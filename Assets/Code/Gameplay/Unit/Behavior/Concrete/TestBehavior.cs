using Gameplay.Unit.Behavior.Comps;
using Gameplay.Unit.Behavior.Nodes.Special;
using Gameplay.Unit.Behavior.Nodes.Special.Movement;
using Gameplay.Unit.Behavior.Nodes.Structural;
using UnityEngine;

namespace Gameplay.Unit.Behavior.Concrete {
   [CreateAssetMenu]
   public class TestBehavior : ScrBehavior {
      [SerializeField, Min(min: 0f)] private float waitTime = .25f;


      protected override BehaviorTree GetBehaviorTree() => new(new DoRepeat(new IfTargetPlayer(new DoMoveToTarget(), new DoWait(waitTime, new DoMoveToRandomPosition()))));
   }
}