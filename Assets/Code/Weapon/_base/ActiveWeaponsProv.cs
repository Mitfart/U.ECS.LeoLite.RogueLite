using System;
using System.Collections.Generic;
using System.Linq;
using Extensions.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Mitfart.LeoECSLite.UnityIntegration.Attributes;
using UnityEngine;

namespace Weapon {
  [DisallowMultipleComponent]
  public sealed class ActiveWeaponsProv : BaseEcsProvider {
    [field: SerializeField] public List<WeaponProv> Weapons { get; private set; }

    private void OnValidate() {
      if (Weapons is { Count: > 0 })
        Weapons = Weapons.ToHashSet().ToList();
    }

    public override void Convert(int e, EcsWorld world) {
      world.GetPool<ActiveWeapons>()
           .Set(e)
           .weapons = Weapons.ConvertAll(Convert);

      Destroy(this);
    }

    private static EcsPackedEntity Convert(WeaponProv provider) => provider.GetComponent<ConvertToEntity>();
  }

  [Serializable]
  public struct ActiveWeapons {
    [PackedEntity] public List<EcsPackedEntity> weapons;
  }
}