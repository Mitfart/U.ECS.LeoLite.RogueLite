using Leopotam.EcsLite;
using UnityEngine;
using View;

namespace Gameplay.Interactable {
   public class InteractableView : EcsView {
      public override void Refresh(EcsWorld world, int entity) {
         if (Hovered(world, entity))
            Hover();
         else
            Unhover();
      }

      private void Hover()   => transform.localScale = Vector3.one * 1.2f;
      private void Unhover() => transform.localScale = Vector3.one;

      private static bool Hovered(EcsWorld world, int entity) => world.GetPool<Hovered>().Has(entity);
   }
}