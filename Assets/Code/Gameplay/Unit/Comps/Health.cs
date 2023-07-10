using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Unit.Comps {
   [Serializable]
   public struct Health {
      [Min(min: 0)] public float cur;
      [Min(min: 0)] public float max;
   }
}