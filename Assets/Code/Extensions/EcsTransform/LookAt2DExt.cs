using UnityEngine;

namespace Extensions.EcsTransform {
  public static class LookAt2DExt {
    public static ref UnityRef.EcsTransform LookAt2D(ref this UnityRef.EcsTransform cur, Vector3 target, Vector3? viewDir = null) {
      float deltaAngle = Vector2.SignedAngle(viewDir ?? cur.Up(), target - cur.Position);

      if (TooSmall(deltaAngle))
        return ref cur;

      Vector3 angles = cur.EulerAngles();
      angles.z += deltaAngle;
      cur.SetEulerAngles(angles);
      return ref cur;
    }

    public static ref UnityRef.EcsTransform LookAt2D(ref this UnityRef.EcsTransform cur, UnityRef.EcsTransform target, Vector3? viewDir = null) => ref cur.LookAt2D(target.Position, viewDir);



    private static bool TooSmall(float deltaAngle) => Mathf.Abs(deltaAngle) < 1e-3f;
  }
}