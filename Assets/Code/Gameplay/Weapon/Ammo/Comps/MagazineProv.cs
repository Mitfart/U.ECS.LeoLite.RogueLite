using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Weapon.Ammo {
   [DisallowMultipleComponent]
   public class MagazineProv : EcsProvider<Magazine> {
      private void OnValidate() {
         if (component.amount > component.size) component.size = component.amount;
      }
   }

   [Serializable]
   public struct Magazine {
      [Min(min: 0)] public int amount;
      [Min(min: 0)] public int size;
   }
}