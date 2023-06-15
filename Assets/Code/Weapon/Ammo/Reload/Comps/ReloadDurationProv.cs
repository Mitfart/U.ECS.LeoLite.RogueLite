using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Battle.Weapon.Ammo.Reload {
  [DisallowMultipleComponent] public class ReloadDurationProv : EcsProvider<ReloadDuration> { }

  [Serializable]
  public struct ReloadDuration {
    public float duration;

    [HideInInspector] public float startTime;
  }
}