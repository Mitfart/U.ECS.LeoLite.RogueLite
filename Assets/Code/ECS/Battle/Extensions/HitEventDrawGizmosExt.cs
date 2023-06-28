﻿using UnityEngine;

namespace ECS.Battle.Extensions {
   public static class HitEventDrawGizmosExt {
      public static void DrawGizmos(this HitEvent hit) {
         Gizmos.color = Color.yellow;
         Gizmos.DrawLine(hit.point, hit.point + hit.normal);
      }
   }
}