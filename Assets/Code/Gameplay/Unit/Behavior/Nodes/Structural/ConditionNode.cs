using Leopotam.EcsLite;

namespace Unit.Behavior.Nodes.Structural {
   public abstract class ConditionNode : BehaviorNode {
      private BehaviorNode True  { get; }
      private BehaviorNode False { get; }



      protected ConditionNode(BehaviorNode @true, BehaviorNode @false) : base(@true, @false) {
         True  = @true;
         False = @false;
      }



      protected override BehaviorState OnRun(int e, EcsWorld world) => Condition(e, world) ? True.Run(e, world) : False.Run(e, world);


      protected abstract bool Condition(int e, EcsWorld world);
   }
}