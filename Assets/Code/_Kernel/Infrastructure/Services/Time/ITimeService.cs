namespace Infrastructure.Services.Time {
   public interface ITimeService {
      float Delta      { get; }
      float FixedDelta { get; }
      float Time       { get; }
      float RealTime   { get; }
      float LevelTime  { get; }
      float ReverseDelta  { get; }

      float Elapsed(float  startTime);
      bool  PassTime(float startTime, float duration);
   }
}