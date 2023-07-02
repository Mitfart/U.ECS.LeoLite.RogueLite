using System;
using VContainer.Unity;

namespace Engine {
   public interface IEngine : IInitializable, ITickable, IFixedTickable, IDisposable {
      public bool Enabled { get; }

      public void Enable();
      public void Disable();
   }
}