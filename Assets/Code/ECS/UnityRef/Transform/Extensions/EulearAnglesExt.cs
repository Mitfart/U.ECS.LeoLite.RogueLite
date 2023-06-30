using UnityEngine;

namespace ECS.UnityRef.Extensions {
   public static class EulearAnglesExt {
      public static Vector3 EulerAngles(ref this EcsTransform t) => t.Rotation.eulerAngles;

      public static void SetEulerAngles(ref this EcsTransform t, Vector3 v) => t.Rotation = Quaternion.Euler(v);
   }
}