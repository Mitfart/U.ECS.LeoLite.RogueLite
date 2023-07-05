using UnityEngine;

namespace Infrastructure.AssetsManagement {
   public interface IAssets {
      T Ins<T>(T       obj,  Vector3 at = default, Quaternion? rot = null, Transform parent = null) where T : Object;
      T Ins<T>(string  path, Vector3 at = default, Quaternion? rot = null, Transform parent = null) where T : Object;
      T Load<T>(string path) where T : Object;

      Object Ins(Object  obj,  Vector3 at = default, Quaternion? rot = null, Transform parent = null);
      Object Ins(string  path, Vector3 at = default, Quaternion? rot = null, Transform parent = null);
      Object Load(string path);
   }
}