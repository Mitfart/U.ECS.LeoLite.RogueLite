using UnityEngine;

namespace ECS.UnityRef.Extensions {
   public static class DirectionExt {
      public static Vector3 Right(ref this EcsTransform t) => t.Dir(Vector3.right);

      public static void Right(ref this EcsTransform t, Vector3 v) => t.Dir(Vector3.right, v);

      public static Vector3 Up(ref this EcsTransform t) => t.Dir(Vector3.up);

      public static void Up(ref this EcsTransform t, Vector3 v) => t.Dir(Vector3.up, v);

      public static Vector3 Dir(ref this EcsTransform t, Vector3 dir) => t.Rotation * dir;

      public static void Dir(ref this EcsTransform t, Vector3 dir, Vector3 v) => t.Rotation = Quaternion.FromToRotation(dir, v);
   }
}