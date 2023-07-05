using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.AssetsManagement {
   public sealed class Assets : IAssets {
      private readonly IObjectResolver _di;

      public Assets(IObjectResolver di) => _di = di;

      public T Ins<T>(T       obj,  Vector3 at = default, Quaternion? rot = null, Transform parent = null) where T : Object => _di.Instantiate(obj, at, rot ?? Quaternion.identity, parent);
      public T Ins<T>(string  path, Vector3 at = default, Quaternion? rot = null, Transform parent = null) where T : Object => Ins(Load<T>(path), at, rot   ?? Quaternion.identity, parent);
      public T Load<T>(string path) where T : Object => Resources.Load<T>(path);

      public Object Ins(Object  obj,  Vector3 at = default, Quaternion? rot = null, Transform parent = null) => _di.Instantiate(obj, at, rot ?? Quaternion.identity, parent);
      public Object Ins(string  path, Vector3 at = default, Quaternion? rot = null, Transform parent = null) => Ins(Load(path), at, rot      ?? Quaternion.identity, parent);
      public Object Load(string path) => Resources.Load(path);
   }
}