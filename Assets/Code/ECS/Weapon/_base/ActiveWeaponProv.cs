using System;
using Extensions.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Mitfart.LeoECSLite.UnityIntegration.Attributes;
using UnityEngine;

namespace Features.Weapon {
  [DisallowMultipleComponent]
  public sealed class ActiveWeaponProv : BaseEcsProvider {
    [field: SerializeField] public WeaponTagProv Weapon { get; private set; }

    public override void Convert(int e, EcsWorld world) {
      world.GetPool<ActiveWeapon>()
           .Set(e)
           .weapon = Weapon.GetComponent<ConvertToEntity>();

      Destroy(this);
    }
  }

  [Serializable]
  public struct ActiveWeapon {
    [PackedEntity] public EcsPackedEntity weapon;
  }
}