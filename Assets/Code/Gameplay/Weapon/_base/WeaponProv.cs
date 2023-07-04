using System;
using Extensions.Ecs;
using Extensions.Unileo;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Weapon._base {
   [DisallowMultipleComponent]
   public class WeaponProv : BaseEcsProvider<Weapon> {
      public WeaponOwnerProv owner;

      private void OnValidate() {
         if (!owner.IsUnityNull())
            owner.weapon = this;
      }

      protected override void Add(EcsPool<Weapon> pool, int e, EcsWorld world)
         => pool.Set(e).owner =
            !owner.IsUnityNull()
               ? owner.AsPackedEntityWithWorld()
               : null;
   }

   [Serializable]
   public struct Weapon {
      public EcsPackedEntityWithWorld? owner;
   }
}