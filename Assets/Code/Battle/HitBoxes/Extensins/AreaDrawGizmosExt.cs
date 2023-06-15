using UnityEngine;

namespace Battle.HitBoxes.Extensins {
  public static class AreaDrawGizmosExt {
    public static void DrawGizmos(this Area area, Matrix4x4 matrix, Color? color = null) {
      const float COLOR_FILL_OPACITY   = .25f;
      const float COLOR_BORDER_OPACITY = 1f;

      Color col = color ?? Color.white;

      col.a        = COLOR_FILL_OPACITY;
      Gizmos.color = col;

      Gizmos.matrix = matrix;
      Gizmos.DrawCube(area.origin, area.size);

      col.a        = COLOR_BORDER_OPACITY;
      Gizmos.color = col;
      Gizmos.DrawWireCube(area.origin, area.size);
    }
  }
}