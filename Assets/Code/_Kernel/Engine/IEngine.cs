using System;
using VContainer.Unity;

namespace Engine {
  public interface IEngine : IInitializable, ITickable, IFixedTickable, IDisposable { }
}