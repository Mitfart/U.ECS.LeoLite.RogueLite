using UnityEngine;

namespace Extensions.EcsTransform {
  public static class MatrixExt {
    public static Matrix4x4 Matrix(this ref UnityRef.EcsTransform t)
      => Matrix4x4.TRS(
        t.Position,
        t.Rotation,
        Vector3.one * t.Scale
      );
  }
}