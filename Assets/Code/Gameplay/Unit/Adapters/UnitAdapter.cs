using Gameplay.Unit.Behavior.Concrete;
using Gameplay.Unit.Behavior.ECS.Comps;
using Gameplay.Unit.Comps;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Structs.Optional;
using UnityEngine;
using VContainer;

namespace Gameplay.Unit.Adapters {
   public class UnitAdapter : EcsAdapter<Comps.Unit> {
      public Health                health;
      public Damage                damage;
      public InvincibilityDuration invincibilityDuration;
      public Penetration           penetration;
      public ViewRadius            viewRadius;
      public Optional<ScrBehavior> ai;

      private IObjectResolver _di;



      [Inject]
      public void Construct(IObjectResolver di) {
         _di = di;
      }

      public override void Convert() {
         base.Convert();

         Set(health);
         Set(damage);
         Set(invincibilityDuration);
         Set(penetration);
         Set(viewRadius);

         if (ai.Enabled)
            Set(ai.Value.Get()).Behavior.Init(Converter.Entity, Converter.World, _di);
      }



      private void OnDrawGizmos() {
         Gizmos.color = Color.cyan;
         Gizmos.DrawWireSphere(transform.position, viewRadius.value);
      }
   }
}