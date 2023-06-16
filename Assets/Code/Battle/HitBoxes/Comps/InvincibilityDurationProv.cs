using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Battle.HitBoxes {
  [DisallowMultipleComponent] public class InvincibilityDurationProv : EcsProvider<InvincibilityDuration> { }

  [Serializable]
  public struct InvincibilityDuration {
    public float value;
  }
}