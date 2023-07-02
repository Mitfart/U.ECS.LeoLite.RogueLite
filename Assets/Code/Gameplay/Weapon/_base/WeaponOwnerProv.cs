using System;
using Extensions.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Mitfart.LeoECSLite.UnityIntegration.Attributes;
using UnityEngine;

namespace Weapon {
   [DisallowMultipleComponent]
   public sealed class WeaponOwnerProv : BaseEcsProvider {
      [field: SerializeField] public WeaponTagProv Weapon { get; private set; }

      public override void Convert(int e, EcsWorld world) {
         world.GetPool<WeaponOwner>().Set(e).Weapon = Weapon.GetComponent<ConvertToEntity>();

         Destroy(this);
      }
   }

   [Serializable]
   public struct WeaponOwner {
      [PackedEntity] public EcsPackedEntity Weapon;
   }
}