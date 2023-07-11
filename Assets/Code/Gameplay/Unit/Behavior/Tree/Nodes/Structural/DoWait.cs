using Infrastructure.Services.Time;
using Structs.Ranged;
using VContainer;

namespace Gameplay.Unit.Behavior.Tree.Nodes.Structural {
   public class DoWait : BehaviorNode {
      private readonly Ranged _rangedDuration;

      private ITimeService _timeService;

      private float _duration;
      private float _startTime;



      public DoWait(Ranged rangedDuration, params BehaviorNode[] childNodes) : base(childNodes) {
         _rangedDuration = rangedDuration;
      }

      protected override void OnInit() {
         _timeService = Di.Resolve<ITimeService>();
      }

      protected override void OnBegin() {
         _startTime = _timeService.Time;
         _duration  = _rangedDuration.Random();
      }

      protected override BehaviorState OnRun()
         => !IsTimerEnd()
            ? BehaviorState.Run
            : base.OnRun();



      private bool IsTimerEnd() => _timeService.PassTime(_startTime, _duration);
   }
}