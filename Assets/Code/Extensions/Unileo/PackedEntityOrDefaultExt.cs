using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Extensions.Unileo {
  public static class PackedEntityOrDefaultExt {
    public static EcsPackedEntity PackedEntityOrDefault(this Component component)
      => component != null && component.OnEntity(out ConvertToEntity entity)
        ? entity
        : default;

    public static EcsPackedEntityWithWorld PackedEntityWWOrDefault(this Component component)
      => component != null && component.OnEntity(out ConvertToEntity entity)
        ? entity
        : default;
  }
}