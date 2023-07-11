using Infrastructure.Services.Time;
using VContainer;

namespace Gameplay.Unit.Behavior.Tree.Nodes.Structural {
   public class DoWait : BehaviorNode {
      private readonly float _duration;

      private ITimeService _timeService;

      private float _startTime;



      public DoWait(float duration, params BehaviorNode[] childNodes) : base(childNodes) {
         _duration = duration;
      }

      protected override void OnInit() => _timeService = Di.Resolve<ITimeService>();

      protected override void OnBegin() => _startTime = _timeService.Time;

      protected override BehaviorState OnRun()
         => !IsTimerEnd()
            ? BehaviorState.Run
            : base.OnRun();



      private bool IsTimerEnd() => _timeService.Time - _startTime >= _duration;
   }
}