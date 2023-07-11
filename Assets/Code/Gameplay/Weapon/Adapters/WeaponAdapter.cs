using System.Collections.Generic;
using Gameplay.UnityRef.Transform.Extensions;
using Gameplay.Weapon.Ammo.Comps;
using Gameplay.Weapon.Ammo.Reload;
using Gameplay.Weapon.Attack.Comps;
using Gameplay.Weapon.Shooting.Comps;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Structs.Optional;
using Structs.Ranged;
using UnityEngine;

namespace Gameplay.Weapon.Adapters {
   public class WeaponAdapter : EcsAdapter<_base.Weapon> {
      [Min(0)] public int   magazineSize;
      [Min(0)] public float restoreAttackDuration;

      public Optional<Reload> reload;
      public Optional<Ranged> spreadAngle = new(new Ranged(0f, 0f, -180f, 180f));

      public List<ProjectileAdapter> projectiles;
      public List<Transform>         projectilesSpawnOrigins;



      public override void Convert() {
         base.Convert();

         Set<Magazine>()                    = new Magazine { amount = magazineSize, size = magazineSize };
         Set<RestoreAttackTimer>().duration = restoreAttackDuration;

         if (spreadAngle.Enabled)
            Set<SpreadAngle>().angle = spreadAngle.Value;

         if (reload.Enabled)
            Set(reload.Value);

         Set<Projectiles>().value             = projectiles.Count             > 0 ? projectiles.ConvertAll(projectile => projectile.name) : null;
         Set<ProjectilesSpawnOrigins>().value = projectilesSpawnOrigins.Count > 0 ? projectilesSpawnOrigins.ConvertAll(t => t.ToEcs()) : null;
      }
   }
}