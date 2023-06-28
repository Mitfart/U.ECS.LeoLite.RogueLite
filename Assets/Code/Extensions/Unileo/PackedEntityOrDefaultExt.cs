using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Extensions.Unileo {
   public static class PackedEntityOrDefaultExt {
      public static EcsPackedEntity? AsPackedEntity(this Component component) {
         return component != null && component.OnEntity(out ConvertToEntity entity) ? entity : null;
      }

      public static EcsPackedEntityWithWorld? AsPackedEntityWithWorld(this Component component) {
         return component != null && component.OnEntity(out ConvertToEntity entity) ? entity : null;
      }

      public static EcsPackedEntity? AsPackedEntity(this ConvertToEntity entity) {
         return entity;
      }

      public static EcsPackedEntityWithWorld? AsPackedEntityWithWorld(this ConvertToEntity entity) {
         return entity;
      }
   }
}