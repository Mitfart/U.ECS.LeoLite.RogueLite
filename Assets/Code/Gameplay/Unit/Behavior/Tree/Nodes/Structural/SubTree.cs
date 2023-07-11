namespace Gameplay.Unit.Behavior.Tree.Nodes.Structural {
   public class SubTree : BehaviorNode {
      private readonly BehaviorTree _behaviorTree;



      public SubTree(BehaviorTree behaviorTree) {
         _behaviorTree = behaviorTree;
      }



      protected override BehaviorState OnRun() => _behaviorTree.Run();
   }
}