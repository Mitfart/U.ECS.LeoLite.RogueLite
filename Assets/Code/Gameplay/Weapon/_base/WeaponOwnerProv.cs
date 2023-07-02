using System;
using Extensions.Ecs;
using Extensions.Unileo;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Mitfart.LeoECSLite.UnityIntegration.Attributes;
using UnityEngine;

namespace Gameplay.Weapon._base {
   [DisallowMultipleComponent]
   public sealed class WeaponOwnerProv : BaseEcsProvider<WeaponOwner> {
      [field: SerializeField] public WeaponTagProv Weapon { get; private set; }

      protected override void Add(EcsPool<WeaponOwner> pool, int e, EcsWorld world) => pool.Set(e).Weapon = Weapon.AsPackedEntity();
   }

   [Serializable]
   public struct WeaponOwner {
      [PackedEntity] public EcsPackedEntity Weapon;
   }
}