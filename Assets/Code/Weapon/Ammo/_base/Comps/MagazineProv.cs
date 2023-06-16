using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Weapon.Ammo._base {
  [DisallowMultipleComponent]
  public class MagazineProv : EcsProvider<Magazine> {
    private void OnValidate() {
      if (component.amount > component.size)
        component.size = component.amount;
    }
  }

  [Serializable]
  public struct Magazine {
    [Min(0)] public int amount;
    [Min(0)] public int size;
  }
}