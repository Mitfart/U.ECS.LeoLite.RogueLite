using Leopotam.EcsLite;
using UnityEngine;

namespace Behavior.Nodes.Structural {
  public class DoWait : BehaviorNode {
    private readonly float _duration;
    private          float _startTime;



    public DoWait(float duration, params BehaviorNode[] childNodes) : base(childNodes) {
      _duration = duration;
    }



    protected override void OnBegin(int e, EcsWorld world) {
      _startTime = Time.time;
    }

    protected override BehaviorState OnRun(int e, EcsWorld world) {
      return !IsTimerEnd() 
        ? BehaviorState.Run 
        : base.OnRun(e, world);
    }



    private bool IsTimerEnd() => Time.time - _startTime >= _duration;
  }
}