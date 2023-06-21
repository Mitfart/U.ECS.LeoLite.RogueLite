using Leopotam.EcsLite;

namespace Behavior.Nodes.Structural {
  public class SequenceNode : BehaviorNode {
    public SequenceNode(params BehaviorNode[] childNodes) : base(childNodes) { }

    protected override BehaviorState OnRun(int e, EcsWorld world) {
      foreach (BehaviorNode node in ChildNodes) {
        BehaviorState childState = node.Run(e, world);

        if (childState == BehaviorState.Success)
          continue;

        return childState;
      }

      return BehaviorState.Success;
    }
  }
}