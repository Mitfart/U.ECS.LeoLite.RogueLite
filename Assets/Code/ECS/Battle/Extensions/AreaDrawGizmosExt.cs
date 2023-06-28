using ECS.Battle.Structs;
using UnityEngine;

namespace ECS.Battle.Extensions {
   public static class AreaDrawGizmosExt {
      public static void DrawGizmos(this Area area, Matrix4x4 matrix, Color? color = null) {
         const float _COLOR_FILL_OPACITY   = .25f;
         const float _COLOR_BORDER_OPACITY = 1f;

         Color col = color ?? Color.white;

         col.a        = _COLOR_FILL_OPACITY;
         Gizmos.color = col;

         Gizmos.matrix = matrix;
         Gizmos.DrawCube(area.origin, area.size);

         col.a        = _COLOR_BORDER_OPACITY;
         Gizmos.color = col;
         Gizmos.DrawWireCube(area.origin, area.size);
      }
   }
}