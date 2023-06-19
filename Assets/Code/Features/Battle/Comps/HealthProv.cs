using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Features.Battle {
  [DisallowMultipleComponent]
  public class HealthProv : EcsProvider<Health> {
    private void OnValidate() {
      if (component.cur > component.max)
        component.max = component.cur;
    }
  }

  [Serializable]
  public struct Health {
    [Min(0)] public float cur;
    [Min(0)] public float max;
  }
}