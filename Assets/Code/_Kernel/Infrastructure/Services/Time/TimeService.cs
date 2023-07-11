namespace Infrastructure.Services.Time {
   public class TimeService : ITimeService {
      public float Delta        => UnityEngine.Time.deltaTime;
      public float FixedDelta   => UnityEngine.Time.fixedDeltaTime;
      public float Time         => UnityEngine.Time.time;
      public float RealTime     => UnityEngine.Time.realtimeSinceStartup;
      public float LevelTime    => UnityEngine.Time.timeSinceLevelLoad;
      public float ReverseDelta => 1f / Delta;


      public float Elapsed(float  startTime)                 => Time - startTime;
      public bool  PassTime(float startTime, float duration) => Elapsed(startTime) >= duration;
   }
}