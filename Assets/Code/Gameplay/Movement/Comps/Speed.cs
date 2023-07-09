using System;
using UnityEngine;

namespace Gameplay.Movement.Comps {
   [Serializable]
   public struct Speed {
      [Min(0)] public float value;
   }
}