using System;
using Gameplay.HitBoxes.Structs;
using UnityEngine;

namespace Gameplay.HitBoxes.Comps {
   [Serializable]
   public struct HitBox {
      public Area      area;
      public LayerMask layerMask;
   }
}