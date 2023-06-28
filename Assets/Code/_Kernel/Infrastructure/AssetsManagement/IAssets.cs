using UnityEngine;

namespace Infrastructure.AssetsManagement {
   public interface IAssets {
      T Ins<T>(T       obj) where T : Object;
      T Ins<T>(string  path) where T : Object;
      T Load<T>(string path) where T : Object;

      Object Ins(Object  obj);
      Object Ins(string  path);
      Object Load(string path);
   }
}