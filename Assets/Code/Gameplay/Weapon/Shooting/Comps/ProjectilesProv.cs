using System;
using System.Collections.Generic;
using Extensions.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Weapon.Shooting.Comps {
   [DisallowMultipleComponent]
   public class ProjectilesProv : BaseEcsProvider<Projectiles> {
      public List<ConvertToEntity> projectiles;

      protected override void Add(EcsPool<Projectiles> pool, int e, EcsWorld world) => pool.Set(e).value = projectiles;
   }

   [Serializable]
   public struct Projectiles {
      public List<ConvertToEntity> value;
   }
}