namespace Infrastructure.Services.Time {
   public class TimeService : ITimeService {
      public float Delta      => UnityEngine.Time.inFixedTimeStep ? FixedDelta : UnityEngine.Time.deltaTime;
      public float FixedDelta => UnityEngine.Time.fixedDeltaTime;
      public float Time       => UnityEngine.Time.time;
      public float RealTime   => UnityEngine.Time.realtimeSinceStartup;
      public float LevelTime  => UnityEngine.Time.timeSinceLevelLoad;
   }
}