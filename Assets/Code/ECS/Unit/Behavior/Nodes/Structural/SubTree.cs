using Leopotam.EcsLite;

namespace Behavior.Nodes.Structural {
  public class SubTree : BehaviorNode {
    private readonly BehaviorTree _behaviorTree;



    public SubTree(BehaviorTree behaviorTree) {
      _behaviorTree = behaviorTree;
    }



    protected override BehaviorState OnRun(int e, EcsWorld world) => _behaviorTree.Run(e, world);
  }
}