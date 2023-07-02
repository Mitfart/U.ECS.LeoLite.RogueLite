using Gameplay.UnityRef.Transform.Comp;
using UnityEngine;

namespace Gameplay.UnityRef.Transform.Extensions {
   public static class SyncExt {
      public static UnityEngine.Transform Sync(this UnityEngine.Transform cur, EcsTransform ecsTransform) {
         cur.position   = ecsTransform.Position;
         cur.rotation   = ecsTransform.Rotation;
         cur.localScale = Vector3.one * ecsTransform.LocalScale;
         return cur;
      }

      public static ref EcsTransform Sync(ref this EcsTransform cur, UnityEngine.Transform transform) {
         cur.Position = transform.position;
         cur.Rotation = transform.rotation;
         cur.Scale    = transform.localScale.x;
         return ref cur;
      }
   }
}