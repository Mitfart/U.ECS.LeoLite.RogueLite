using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Unit.Comps {
   [DisallowMultipleComponent] public class InvincibilityDurationProv : EcsProvider<InvincibilityDuration> { }

   [Serializable]
   public struct InvincibilityDuration {
      public float duration;
   }
}