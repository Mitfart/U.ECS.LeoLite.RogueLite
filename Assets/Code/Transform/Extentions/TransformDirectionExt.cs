using Direction.Extensions;
using UnityEngine;

namespace Extentions {
  public static class TransformDirectionExt {
    public static Vector3 Right(ref this EcsTransform t)            => t.Dir(Direction.Direction.Right);
    public static void    Right(ref this EcsTransform t, Vector3 v) => t.Dir(Direction.Direction.Right, v);

    public static Vector3 Up(ref this EcsTransform t)            => t.Dir(Direction.Direction.Up);
    public static void    Up(ref this EcsTransform t, Vector3 v) => t.Dir(Direction.Direction.Up, v);

    public static Vector3 Dir(ref this EcsTransform t, Direction.Direction dir)            => t.Rotation * dir.GetVector();
    public static void    Dir(ref this EcsTransform t, Direction.Direction dir, Vector3 v) => t.LocalRotation = Quaternion.FromToRotation(dir.GetVector(), v);

    public static Vector3 EulerAngles(ref this EcsTransform t)            => t.Rotation.eulerAngles;
    public static void    EulerAngles(ref this EcsTransform t, Vector3 v) => t.Rotation = Quaternion.Euler(v);
  }
}