using System;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Battle.Weapon {
  [DisallowMultipleComponent] public class WeaponProv : EcsProvider<Weapon> { }

  [Serializable]
  public struct Weapon {
    public EcsPackedEntity owner;
  }
}