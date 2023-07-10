using System;
using Gameplay.HitBoxes.Extensions;
using Gameplay.HitBoxes.Structs;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.HitBoxes.Comps {
   [Serializable]
   public struct HitBox {
      public Area      area;
      public LayerMask layerMask;
   }
}