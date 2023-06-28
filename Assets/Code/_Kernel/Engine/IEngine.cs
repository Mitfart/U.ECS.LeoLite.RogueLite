namespace Engine {
   public interface IEngine {
      public void Init();
      public void Run();
      public void FixedRun();
      public void Dispose();
   }
}