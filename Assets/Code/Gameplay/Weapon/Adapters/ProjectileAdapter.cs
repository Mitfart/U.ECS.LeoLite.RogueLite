using Gameplay.HitBoxes.Comps;
using Gameplay.HitBoxes.Extensions;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Weapon.Adapters {
   public class ProjectileAdapter : EcsAdapter<Projectile> {
      public HitBox hitBox;

      public override void Convert() {
         base.Convert();

         Set(hitBox);
      }

      private void OnDrawGizmos() {
         hitBox.area.DrawGizmos(
            transform.localToWorldMatrix,
            Color.red
         );
      }
   }
}