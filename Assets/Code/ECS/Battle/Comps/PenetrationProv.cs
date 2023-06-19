using System;
using UnityEngine;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Features.Weapon.Projectiles {
  [DisallowMultipleComponent] public class PenetrationProv : EcsProvider<Penetration> { }

  [Serializable]
  public struct Penetration {
    public int amount;

    [HideInInspector] public int elapsedCount;
  }
}