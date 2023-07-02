using UnityEngine;

namespace Gameplay.Movement.Comps {
   public struct PhysicsMovement {
      public float          Accel;
      public AnimationCurve AccelDotFactor;
      public float          MaxAccel;
      public AnimationCurve MaxAccelDotFactor;
   }
}