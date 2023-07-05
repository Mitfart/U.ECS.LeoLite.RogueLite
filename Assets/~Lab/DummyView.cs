using Gameplay.HitBoxes.Comps;
using Gameplay.View.Comps;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Lab {
   public class DummyView : EcsView {
      public SpriteRenderer[] spriteRenderers;

      public override void Refresh(EcsWorld world, int entity) {
         foreach (SpriteRenderer spriteRenderer in spriteRenderers) {
            spriteRenderer.color =
               Invincible(entity, world)
                  ? Color.red
                  : Color.white;
         }
      }

      private static bool Invincible(int entity, EcsWorld world) => world.GetPool<Invincible>().Has(entity);
   }
}