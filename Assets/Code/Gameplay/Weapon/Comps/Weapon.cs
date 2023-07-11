using System;
using Leopotam.EcsLite;

namespace Gameplay.Weapon._base {
   [Serializable]
   public struct Weapon {
      public EcsPackedEntityWithWorld? owner;
   }
}