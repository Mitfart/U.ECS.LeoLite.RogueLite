using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Unit.Comps {
   [DisallowMultipleComponent]
   public class HealthProv : EcsProvider<Health> {
      private void OnValidate() {
         if (component.cur > component.max) component.max = component.cur;
      }
   }

   [Serializable]
   public struct Health {
      [Min(min: 0)] public float cur;
      [Min(min: 0)] public float max;
   }
}