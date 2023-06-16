using System;
using System.Collections.Generic;
using Extensions.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Weapon {
  [DisallowMultipleComponent]
  public class WeaponsOwnerProv : BaseEcsProvider {
    [field: SerializeField] public List<WeaponProv> Weapons { get; private set; }

    public override void Convert(int e, EcsWorld world) {
      world
       .GetPool<ActiveWeapons>()
       .Set(e)
       .weapons = Weapons.ConvertAll(Convert);

      Destroy(this);
    }

    private static EcsPackedEntity Convert(WeaponProv provider) => provider.GetComponent<ConvertToEntity>();
  }

  [Serializable]
  public struct WeaponsOwner {
    public List<EcsPackedEntity> weapons;
  }
}