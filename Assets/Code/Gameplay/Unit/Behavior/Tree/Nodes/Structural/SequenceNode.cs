namespace Gameplay.Unit.Behavior.Tree.Nodes.Structural {
   public class SequenceNode : BehaviorNode {
      public SequenceNode(params BehaviorNode[] childNodes) : base(childNodes) { }

      protected override BehaviorState OnRun() {
         foreach (BehaviorNode node in ChildNodes) {
            BehaviorState childState = node.Run();

            if (childState == BehaviorState.Success)
               continue;

            return childState;
         }

         return BehaviorState.Success;
      }
   }
}