using System;
using UnityEngine;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Features.Weapon.Projectiles {
  [DisallowMultipleComponent] public class DestroyAfterHitsProv : EcsProvider<DestroyAfterHits> { }

  [Serializable]
  public struct DestroyAfterHits {
    public int amount;

    [HideInInspector] public int elapsedCount;
  }
}