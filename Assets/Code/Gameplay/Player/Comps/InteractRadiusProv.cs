using System;
using UnityEngine;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Gameplay.Player.Comps {
   [DisallowMultipleComponent]
   public class InteractRadiusProv : EcsProvider<InteractRadius> {
      private void OnDrawGizmosSelected() {
         Gizmos.color = Color.cyan;
         Gizmos.DrawWireSphere(transform.position, component.value);
      }
   }

   [Serializable]
   public struct InteractRadius {
      public float value;
   }
}