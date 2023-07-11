using Extensions.Ecs;
using Gameplay.View.Comps;
using Leopotam.EcsLite;
using UnityEngine;

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

      private static bool Hovered(EcsWorld world, int entity)
         => world.GetPool<Interactable>().TryGet(entity, out Interactable interactable)
         && interactable.state == Interactable.State.Hovered;
   }
}