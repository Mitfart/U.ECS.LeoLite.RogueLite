using System;
using UnityEngine;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Features.Unit.Comps {
  [DisallowMultipleComponent] public class InvincibilityDurationProv : EcsProvider<InvincibilityDuration> { }

  [Serializable]
  public struct InvincibilityDuration {
    public float duration;
  }
}