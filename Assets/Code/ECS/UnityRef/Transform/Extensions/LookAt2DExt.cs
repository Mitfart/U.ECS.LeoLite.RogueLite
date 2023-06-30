using UnityEngine;

namespace ECS.UnityRef.Extensions {
   public static class LookAt2DExt {
      public static ref EcsTransform LookAt2D(ref this EcsTransform cur, Vector3 target, Vector3? viewDir = null) {
         float deltaAngle = Vector2.SignedAngle(viewDir ?? cur.Up(), target - cur.Position);

         if (TooSmall(deltaAngle)) return ref cur;

         Vector3 angles = cur.EulerAngles();
         angles.z += deltaAngle;
         cur.SetEulerAngles(angles);
         return ref cur;
      }

      public static ref EcsTransform LookAt2D(ref this EcsTransform cur, EcsTransform target, Vector3? viewDir = null) => ref cur.LookAt2D(target.Position, viewDir);



      private static bool TooSmall(float deltaAngle) => Mathf.Abs(deltaAngle) < 1e-3f;
   }
}