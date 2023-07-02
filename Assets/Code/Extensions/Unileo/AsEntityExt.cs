using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Extensions.Unileo {
   public static class AsEntityExt {
      public static int                      AsEntity(this                ConvertToEntity entity) => entity.Convert().Entity;
      public static EcsPackedEntity          AsPackedEntity(this          ConvertToEntity entity) => entity.Convert().Packed;
      public static EcsPackedEntityWithWorld AsPackedEntityWithWorld(this ConvertToEntity entity) => entity.Convert().PackedWithWorld;

      public static int                      AsEntity(this                BaseEcsProvider provider) => provider.GetComponent<ConvertToEntity>().AsEntity();
      public static EcsPackedEntity          AsPackedEntity(this          BaseEcsProvider provider) => provider.GetComponent<ConvertToEntity>().AsPackedEntity();
      public static EcsPackedEntityWithWorld AsPackedEntityWithWorld(this BaseEcsProvider provider) => provider.GetComponent<ConvertToEntity>().AsPackedEntityWithWorld();
   }
}