using Gameplay.UnityRef.Transform.Comp;
using UnityEngine;

namespace Gameplay.UnityRef.Transform.Extensions {
   public static class MoveToExt {
      public static ref EcsTransform MoveTo(this ref EcsTransform transform, Vector3 target, float distance) {
         transform.Position = Vector3.MoveTowards(transform.Position, target, distance);
         return ref transform;
      }
      
      public static ref EcsTransform MoveBy(this ref EcsTransform transform, Vector3 velocity) {
         transform.Position += velocity;
         return ref transform;
      }
   }
}