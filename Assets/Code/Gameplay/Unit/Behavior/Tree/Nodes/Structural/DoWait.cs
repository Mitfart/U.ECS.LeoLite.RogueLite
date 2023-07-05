namespace Gameplay.Unit.Behavior.Nodes.Structural {
   public class DoWait : BehaviorNode {
      private readonly float _duration;

      private float _startTime;



      public DoWait(float duration, params BehaviorNode[] childNodes) : base(childNodes) {
         _duration = duration;
      }



      protected override void OnBegin() {
         _startTime = TimeService.Time;
      }

      protected override BehaviorState OnRun()
         => !IsTimerEnd()
            ? BehaviorState.Run
            : base.OnRun();



      private bool IsTimerEnd() => TimeService.Time - _startTime >= _duration;
   }
}