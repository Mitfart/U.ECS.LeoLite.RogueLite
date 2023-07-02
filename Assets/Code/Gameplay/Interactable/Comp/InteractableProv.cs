using System;
using UnityEngine;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Gameplay.Interactable {
   [DisallowMultipleComponent]
   public class InteractableProv : EcsProvider<Interactable> {
      private void OnDrawGizmosSelected() {
         Gizmos.color = Color.cyan;
         Gizmos.DrawWireSphere(transform.position, component.radius);
      }
   }

   [Serializable]
   public struct Interactable {
      [Min(0f)] public float radius;
   }
}