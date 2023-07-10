using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.HitBoxes.Comps {
   [Serializable]
   public struct HurtBox {
      public Collider2D collider;
   }
}