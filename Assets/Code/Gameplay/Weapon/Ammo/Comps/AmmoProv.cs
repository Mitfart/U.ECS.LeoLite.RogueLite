using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Weapon.Ammo.Comps {
   [DisallowMultipleComponent]
   public class AmmoProv : EcsProvider<Ammo> {
      private void OnValidate() {
         if (component.amount > component.size)
            component.size = component.amount;
      }
   }

   [Serializable]
   public struct Ammo {
      [Min(min: 0)] public int amount;
      [Min(min: 0)] public int size;
   }
}