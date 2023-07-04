using System;
using Extensions.Ecs;
using Extensions.Unileo;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Weapon._base {
   [DisallowMultipleComponent]
   public sealed class WeaponOwnerProv : BaseEcsProvider<WeaponOwner> {
      public WeaponProv weapon;

      private void OnValidate() {
         if (!weapon.IsUnityNull())
            weapon.owner = this;
      }

      protected override void Add(EcsPool<WeaponOwner> pool, int e, EcsWorld world)
         => pool.Set(e).weapon =
            !weapon.IsUnityNull()
               ? weapon.AsPackedEntityWithWorld()
               : null;
   }

   [Serializable]
   public struct WeaponOwner {
      public EcsPackedEntityWithWorld? weapon;
   }
}