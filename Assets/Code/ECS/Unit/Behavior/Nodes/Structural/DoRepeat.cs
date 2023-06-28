using Leopotam.EcsLite;

namespace ECS.Unit.Behavior.Nodes.Structural {
   public class DoRepeat : BehaviorNode {
      public DoRepeat(params BehaviorNode[] childNodes) : base(childNodes) { }

      protected override BehaviorState OnRun(int e, EcsWorld world) {
         base.OnRun(e, world);
         return BehaviorState.Run;
      }
   }
}