using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Extensions {
  public static class IsEntityExt {
    public static bool IsEntity(this GameObject gameObject, out ConvertToEntity convertToEntity) => gameObject.TryGetComponent(out convertToEntity);
    public static bool OnEntity(this Component  component,  out ConvertToEntity convertToEntity) => component.gameObject.IsEntity(out convertToEntity);
  }
}