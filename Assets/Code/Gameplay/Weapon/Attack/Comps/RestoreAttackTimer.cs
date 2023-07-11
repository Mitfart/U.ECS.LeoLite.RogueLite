using System;
using UnityEngine;

namespace Gameplay.Weapon.Attack.Comps {
   [Serializable]
   public struct RestoreAttackTimer {
      public float duration;

      [HideInInspector] public float startTime;
   }
}