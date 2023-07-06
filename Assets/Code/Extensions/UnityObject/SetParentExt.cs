using UnityEngine;

namespace Extensions.UnityObject {
   public static class SetParentExt {
      public static TObj SetParent<TObj>(this TObj obj, Transform parent) where TObj : Component {
         obj.transform.SetParent(parent);
         return obj;
      }

      public static GameObject SetParent(this GameObject obj, Transform parent) {
         obj.transform.SetParent(parent);
         return obj;
      }
   }
}