using VContainer.Unity;

namespace Engine {
  public interface IEngine : ITickable, IFixedTickable {
    void Start();
    void Stop();
  }
}