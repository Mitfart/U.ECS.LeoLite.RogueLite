using UnityEngine;

namespace Infrastructure.AssetsManagement {
   public sealed class Assets : IAssets {
      public T Ins<T>(T       obj,  Vector3 at = default, Quaternion? rot = null) where T : Object => Object.Instantiate(obj, at, rot ?? Quaternion.identity);
      public T Ins<T>(string  path, Vector3 at = default, Quaternion? rot = null) where T : Object => Ins(Load<T>(path), at);
      public T Load<T>(string path) where T : Object => Resources.Load<T>(path);

      public Object Ins(Object  obj,  Vector3 at = default, Quaternion? rot = null) => Object.Instantiate(obj, at, rot ?? Quaternion.identity);
      public Object Ins(string  path, Vector3 at = default, Quaternion? rot = null) => Ins(Load(path), at);
      public Object Load(string path) => Resources.Load(path);
   }
}