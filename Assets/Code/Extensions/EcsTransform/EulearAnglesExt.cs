using UnityEngine;

namespace Extensions.EcsTransform {
  public static class EulearAnglesExt {
    public static Vector3 EulerAngles(ref this UnityRef.EcsTransform t) => t.Rotation.eulerAngles;

    public static void SetEulerAngles(ref this UnityRef.EcsTransform t, Vector3 v) => t.Rotation = Quaternion.Euler(v);
  }
}