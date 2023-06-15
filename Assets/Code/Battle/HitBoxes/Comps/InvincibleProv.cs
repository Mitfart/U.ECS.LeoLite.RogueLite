using System;
using UnityEngine;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Battle.HitBoxes {
  [DisallowMultipleComponent] public class InvincibleProv : EcsProvider<Invincible> { }

  [Serializable]
  public struct Invincible {
    public float duration;

    [HideInInspector] public float startTime;
  }
}