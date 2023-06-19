using UnityEngine;

namespace Extensions.EcsTransform {
  public static class SyncExt {
    public static Transform Sync(this Transform cur, UnityRef.EcsTransform ecsTransform) {
      cur.position   = ecsTransform.Position;
      cur.rotation   = ecsTransform.Rotation;
      cur.localScale = Vector3.one * ecsTransform.LocalScale;
      return cur;
    }

    public static ref UnityRef.EcsTransform Sync(ref this UnityRef.EcsTransform cur, Transform transform) {
      cur.Position   = transform.position;
      cur.Rotation   = transform.rotation;
      cur.LocalScale = transform.localScale.x;
      return ref cur;
    }
  }
}