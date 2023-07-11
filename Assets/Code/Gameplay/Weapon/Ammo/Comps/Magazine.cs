using System;
using UnityEngine;

namespace Gameplay.Weapon.Ammo.Comps {
   [Serializable]
   public struct Magazine {
      [Min(min: 0)] public int amount;
      [Min(min: 0)] public int size;

      public bool IsFull()  => amount >= size;
      public bool IsEmpty() => amount <= 0;
   }
}