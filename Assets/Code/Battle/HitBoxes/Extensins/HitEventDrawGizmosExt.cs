using Leopotam.EcsLite;
using UnityEngine;

namespace Battle.HitBoxes.Extensins {
  public static class HitEventDrawGizmosExt {
    public static void DrawGizmos(this HitEvent hit, EcsWorld world) {
      Gizmos.color = Color.yellow;
      Gizmos.DrawLine(hit.Point, hit.Point + hit.Normal);
    }
  }
}