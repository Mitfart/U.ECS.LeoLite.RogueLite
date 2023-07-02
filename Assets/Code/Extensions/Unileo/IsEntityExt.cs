using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Extensions.Unileo {
   public static class IsEntityExt {
      public static bool IsEntity(this GameObject gameObject, out ConvertToEntity convertToEntity) => gameObject.TryGetComponent(out convertToEntity);
      public static bool OnEntity(this Component  component,  out ConvertToEntity convertToEntity) => component.TryGetComponent(out convertToEntity);
   }
}