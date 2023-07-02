using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Extensions.Unileo {
   public static class ParentEntityExt {
      public static bool ParentEntity(this Component component, out int entity) {
         entity = -1;
         return component.ParentEntity().AsPackedEntityWithWorld().Unpack(out EcsWorld _, out entity);
      }

      public static bool ParentEntity(this Component component, out EcsWorld world, out int entity) {
         world  = null;
         entity = -1;
         return component.ParentEntity().AsPackedEntityWithWorld().Unpack(out world, out entity);
      }

      public static ConvertToEntity ParentEntity(this Component component) => component.transform.ParentEntity();

      public static ConvertToEntity ParentEntity(this Transform transform) {
         if (transform == null)
            return null;

         while (transform.parent) {
            transform = transform.parent;

            if (transform.TryGetComponent(out ConvertToEntity entity))
               return entity;
         }

         return null;
      }
   }
}