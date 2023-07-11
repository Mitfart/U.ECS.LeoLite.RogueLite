using Gameplay.Interactable.Extensions;
using Gameplay.Player.Comps;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Gameplay.Player.Adapters {
   public class PlayerAdapter : EcsAdapter<Player.Comps.Player> {
      public Interactor interactor;


      public override void Convert() {
         base.Convert();

         Set(interactor);
      }


      private void OnDrawGizmos() {
         interactor.DrawGizmos(transform.position);
      }
   }
}