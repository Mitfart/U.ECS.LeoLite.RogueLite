using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.AssetsManagement {
  public sealed class Assets {
    public T Ins<T>(string  path) where T : Object => Object.Instantiate(Load<T>(path));
    public T Load<T>(string path) where T : Object => Resources.Load<T>(path);

    public Object Ins(string  path) => Object.Instantiate(Load(path));
    public Object Load(string path) => Resources.Load(path);
  }
}