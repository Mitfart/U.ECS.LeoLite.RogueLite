using Gameplay.Unit.Behavior.ECS.Comps;
using Gameplay.Unit.Comps;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Unit.Adapters {
   public class UnitAdapter : EcsAdapter<Comps.Unit> {
      public Health                health;
      public Damage                damage;
      public InvincibilityDuration invincibilityDuration;
      public Penetration           penetration;
      public ViewRadius            viewRadius;
      public ScrComponent<AI>      ai;

      
      
      public override void Convert() {
         base.Convert();

         Set(health);
         Set(damage);
         Set(invincibilityDuration);
         Set(penetration);
         Set(viewRadius);

         if (!ai.IsUnityNull())
            Set(ai.Get());
      }



      private void OnDrawGizmos() {
         Gizmos.color = Color.cyan;
         Gizmos.DrawWireSphere(transform.position, viewRadius.value);
      }
   }
}