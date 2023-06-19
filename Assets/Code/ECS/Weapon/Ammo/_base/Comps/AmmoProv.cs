using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Features.Weapon.Ammo._base {
  [DisallowMultipleComponent]
  public class AmmoProv : EcsProvider<Ammo> {
    private void OnValidate() {
      if (component.amount > component.size)
        component.size = component.amount;
    }
  }

  [Serializable]
  public struct Ammo {
    [Min(0)] public int amount;
    [Min(0)] public int size;
  }
}