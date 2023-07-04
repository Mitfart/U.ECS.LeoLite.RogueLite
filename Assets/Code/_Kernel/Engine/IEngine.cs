namespace Engine {
   public interface IEngine {
      public bool Enabled { get; }

      public void Enable();
      public void Disable();

      public void Clear();
   }
}