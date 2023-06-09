namespace UnityRef.Extentions {
  public static class SyncExt {
    public static UnityEngine.Transform Sync(this UnityEngine.Transform cur, EcsTransform ecsTransform) {
      cur.position   = ecsTransform.position;
      cur.rotation   = ecsTransform.rotation;
      cur.localScale = ecsTransform.scale;
      return cur;
    }

    public static ref EcsTransform Sync(ref this EcsTransform cur, UnityEngine.Transform transform) {
      cur.position = transform.position;
      cur.rotation = transform.rotation;
      cur.scale    = transform.localScale;
      return ref cur;
    }
  }
}