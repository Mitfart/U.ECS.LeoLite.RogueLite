using Gameplay.Unit.Behavior.ECS;
using Gameplay.Unit.Behavior.Nodes;
using Gameplay.Unit.Behavior.Nodes.Movement;
using Gameplay.Unit.Behavior.Tree;
using Gameplay.Unit.Behavior.Tree.Nodes.Structural;
using Structs.Ranged;
using UnityEngine;

namespace Gameplay.Unit.Behavior.Concrete {
   [CreateAssetMenu]
   public class WalkerTreeBehavior : ScrTreeBehavior {
      [SerializeField, RangeEdges(min: 0f, max: 10f)]
      private Ranged waitTime = new(minV: .25f, maxV: 1f);


      protected override BehaviorTree GetBehaviorTree()
         => new(
            new DoRepeat(
               new IfTargetPlayer(
                  new DoMoveToTarget(),
                  new DoWait(
                     WaitTime(),
                     new DoMoveToRandomPosition()
                  )
               )
            )
         );

      private float WaitTime() => waitTime.GetRandom();
   }
}