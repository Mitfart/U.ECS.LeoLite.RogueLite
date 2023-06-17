using UnityEngine;

namespace Extentions {
  public static class EulearAnglesExt {
    public static Vector3 EulerAngles(ref this EcsTransform t)            => t.Rotation.eulerAngles;
    public static void    EulerAngles(ref this EcsTransform t, Vector3 v) => t.Rotation = Quaternion.Euler(v);
  }
}