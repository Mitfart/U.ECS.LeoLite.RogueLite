using Gameplay.HitBoxes.Comps;
using UnityEngine;

namespace Gameplay.HitBoxes.Extensions {
   public static class HitEventDrawGizmosExt {
      public static void DrawGizmos(this HitEvent hit) {
         Gizmos.color = Color.yellow;
         Gizmos.DrawLine(hit.point, hit.point + hit.normal);
      }
   }
}