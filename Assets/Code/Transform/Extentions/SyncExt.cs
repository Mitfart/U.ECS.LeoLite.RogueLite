using UnityEngine;

namespace Extentions {
  public static class SyncExt {
    public static Transform Sync(this Transform cur, EcsTransform ecsTransform) {
      cur.position   = ecsTransform.Position;
      cur.rotation   = ecsTransform.Rotation;
      cur.localScale = Vector3.one * ecsTransform.LocalScale;
      return cur;
    }

    public static ref EcsTransform Sync(ref this EcsTransform cur, Transform transform) {
      cur.Position   = transform.position;
      cur.Rotation   = transform.rotation;
      cur.LocalScale = transform.localScale.x;
      return ref cur;
    }
  }
}