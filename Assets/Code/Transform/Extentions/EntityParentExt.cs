using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Extentions {
  public static class EntityParentExt {
    public static ConvertToEntity EntityParent(this Component component) => component.transform.EntityParent();
    public static ConvertToEntity EntityParent(this Transform transform) => transform.GetComponentInParent<ConvertToEntity>();
  }
}