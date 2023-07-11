using System;
using Leopotam.EcsLite;

namespace Gameplay.Weapon._base {
   [Serializable]
   public struct WeaponOwner {
      public EcsPackedEntityWithWorld? weapon;
   }
}