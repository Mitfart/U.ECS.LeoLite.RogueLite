using System;
using UnityEngine;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Battle.HitBoxes {
  [DisallowMultipleComponent] public class InvincibilityDurationProv : EcsProvider<InvincibilityDuration> { }

  [Serializable]
  public struct InvincibilityDuration {
    public float value;
  }
}