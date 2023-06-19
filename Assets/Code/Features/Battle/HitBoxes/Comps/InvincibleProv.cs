using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Features.Battle.HitBoxes {
  [DisallowMultipleComponent] public class InvincibleProv : EcsProvider<Invincible> { }

  [Serializable]
  public struct Invincible {
    public float duration;

    [HideInInspector] public float startTime;
  }
}