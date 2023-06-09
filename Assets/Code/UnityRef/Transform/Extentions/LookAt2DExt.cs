using UnityEngine;

namespace UnityRef.Extentions {
  public static class LookAt2DExt {
    public static ref EcsTransform LookAt2D(ref this EcsTransform cur, Vector3 target, Vector3? viewDir = null) {
      float deltaAngle = Vector2.SignedAngle(viewDir ?? cur.Up, target - cur.position);

      if (Mathf.Abs(deltaAngle) < 1e-3f)
        return ref cur;

      Vector3 angles = cur.EulerAngles;
      angles.z        += deltaAngle;
      cur.EulerAngles =  angles;
      return ref cur;
    }

    public static ref EcsTransform LookAt2D(ref this EcsTransform cur, EcsTransform target, Vector3? viewDir = null) {
      return ref cur.LookAt2D(target.position, viewDir);
    }
  }
}