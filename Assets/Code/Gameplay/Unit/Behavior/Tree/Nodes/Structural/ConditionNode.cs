namespace Gameplay.Unit.Behavior.Nodes.Structural {
   public abstract class ConditionNode : BehaviorNode {
      private BehaviorNode True  { get; }
      private BehaviorNode False { get; }



      protected ConditionNode(BehaviorNode @true, BehaviorNode @false) : base(@true, @false) {
         True  = @true;
         False = @false;
      }



      protected override BehaviorState OnRun()
         => Condition()
            ? True.Run()
            : False.Run();


      protected abstract bool Condition();
   }
}