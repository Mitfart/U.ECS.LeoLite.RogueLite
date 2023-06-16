using System;
using System.Collections.Generic;
using Extensions.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Weapon.Projectiles {
  [DisallowMultipleComponent]
  public class ProjectilesProv : BaseEcsProvider {
    public List<ConvertToEntity> projectiles;

    public override void Convert(int e, EcsWorld world) {
      world.GetPool<Projectiles>().Set(e).value = projectiles;
      Destroy(this);
    }
  }

  [Serializable]
  public struct Projectiles {
    public List<ConvertToEntity> value;
  }
}