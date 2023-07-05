using Gameplay.Unit.Behavior.Comps;
using Gameplay.Unit.Behavior.Nodes.Special.Movement;
using Gameplay.Unit.Behavior.Nodes.Structural;
using Structs.Ranged;
using UnityEngine;

namespace Gameplay.Unit.Behavior.Concrete {
   [CreateAssetMenu]
   public class WalkerBehavior : ScrBehavior {
      [SerializeField, RangeEdges(0f, 10f)] private Ranged waitTime = new(.25f, 1f);


      protected override BehaviorTree GetBehaviorTree()
         => new(
            new DoRepeat(
               new DoWait(
                  waitTime.GetRandom(),
                  new DoMoveToRandomPosition()
               )
            )
         );
   }
}