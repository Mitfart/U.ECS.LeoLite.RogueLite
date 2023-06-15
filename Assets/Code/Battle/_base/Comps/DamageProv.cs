using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Battle {
  [DisallowMultipleComponent] public class DamageProv : EcsProvider<Damage> { }

  [Serializable]
  public struct Damage {
    public float value;
  }
}