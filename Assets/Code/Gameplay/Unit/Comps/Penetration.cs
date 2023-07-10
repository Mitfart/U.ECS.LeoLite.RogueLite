using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Unit.Comps {
   [Serializable]
   public struct Penetration {
      public int amount;

      [HideInInspector] public int elapsedCount;
   }
}