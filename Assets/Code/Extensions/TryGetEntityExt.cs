﻿using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Extensions {
  public static class TryGetEntityExt {
    public static bool TryGetEntity(this GameObject gameObject, out int entity) {
      entity = -1; // default
      return gameObject.IsEntity(out ConvertToEntity convert) 
          && convert.TryGetEntity(out entity);
    }

    public static bool TryGetEntity(this Component component, out int entity) {
      return component.gameObject.TryGetEntity(out entity);
    }
  }
}