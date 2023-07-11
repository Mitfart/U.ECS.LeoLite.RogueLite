using Gameplay.Player.Comps;
using UnityEngine;

namespace Gameplay.Interactable.Extensions {
   public static class InteractorGizmosExt {
      public static void DrawGizmos(this Interactor interactor, Vector3 origin) {
         Gizmos.color = Color.cyan;
         Gizmos.DrawWireSphere(origin, interactor.radius);
      }
   }
}