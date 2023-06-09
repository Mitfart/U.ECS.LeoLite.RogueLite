using UnityEngine;

namespace UnityRef.Extentions {
  public static class WithParentExt {
    public static EcsTransform WithParent(ref this EcsTransform cur, in EcsTransform parent) {
      return new EcsTransform(
        cur.WorldPosition(parent),
        cur.WorldRotation(parent),
        cur.WorldScale(parent)
      );
    }

    public static Vector3 WorldPosition(in this EcsTransform cur, in EcsTransform parent)
      => parent.position
       + parent.rotation
       * cur.position;

    public static Quaternion WorldRotation(in this EcsTransform cur, in EcsTransform parent)
      => Quaternion.Euler(
        parent.rotation.eulerAngles
      + cur.EulerAngles
      );

    public static Vector3 WorldScale(in this EcsTransform cur, in EcsTransform parent)
      => new(
        cur.scale.x * parent.scale.x,
        cur.scale.y * parent.scale.y,
        cur.scale.z * parent.scale.z
      );
  }
}