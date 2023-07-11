using System;
using UnityEngine;

namespace Gameplay.Weapon.Ammo.Reload {
   [Serializable]
   public struct Reload {
      public float duration;
      public bool  auto;

      [HideInInspector] public float startTime;
   }
}