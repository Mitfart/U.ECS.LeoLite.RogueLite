using UnityEngine;

namespace Movement {
   public struct PhysicsMovement {
      public float          Accel;
      public AnimationCurve AccelDotFactor;
      public float          MaxAccel;
      public AnimationCurve MaxAccelDotFactor;
   }
}