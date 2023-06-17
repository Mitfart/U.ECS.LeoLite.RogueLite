using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Extentions {
  public static class ParentEntityExt {
    public static EcsPackedEntityWithWorld? ParentEntity(this Component component) => component.transform.ParentEntity();

    public static EcsPackedEntityWithWorld? ParentEntity(this Transform transform) {
      Transform parent = transform.parent;

      if (parent && parent.TryGetComponent(out ConvertToEntity convert))
        return convert;
      
      return null;
    }
  }
}