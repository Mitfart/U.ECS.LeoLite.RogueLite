using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Extensions.Unileo {
   public static class TryGetEntityExt {
      public static bool TryGetEntity(this GameObject gameObject, out int entity) {
         entity = -1; // default
         return gameObject.IsEntity(out ConvertToEntity convert) && convert.AsPackedEntityWithWorld().Unpack(out EcsWorld _, out entity);
      }

      public static bool TryGetEntity(this Component component, out int entity) => component.gameObject.TryGetEntity(out entity);
   }
}