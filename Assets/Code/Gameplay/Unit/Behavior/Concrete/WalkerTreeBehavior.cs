using Gameplay.Unit.Behavior.ECS.Comps;
using Gameplay.Unit.Behavior.Nodes;
using Gameplay.Unit.Behavior.Nodes.Movement;
using Gameplay.Unit.Behavior.Tree;
using Gameplay.Unit.Behavior.Tree.Nodes.Structural;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Structs.Ranged;
using UnityEngine;

namespace Gameplay.Unit.Behavior.Concrete {
   [CreateAssetMenu]
   public class WalkerTreeBehavior : ScrComponent<AI> {
      [SerializeField, RangeEdges(min: 0f, max: 10f)] private Ranged waitTime = new(min: .25f, max: 1f);
      
      protected BehaviorTree GetBehaviorTree()
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