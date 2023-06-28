using UnityEngine;

namespace Infrastructure.AssetsManagement {
   public sealed class Assets : IAssets {
      public T Ins<T>(T       obj) where T : Object  => Object.Instantiate(obj);
      public T Ins<T>(string  path) where T : Object => Ins(Load<T>(path));
      public T Load<T>(string path) where T : Object => Resources.Load<T>(path);

      public Object Ins(Object  obj)  => Object.Instantiate(obj);
      public Object Ins(string  path) => Ins(Load(path));
      public Object Load(string path) => Resources.Load(path);
   }
}