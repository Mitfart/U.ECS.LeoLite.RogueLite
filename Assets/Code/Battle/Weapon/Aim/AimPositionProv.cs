﻿using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Battle.Weapon.Aim {
  [DisallowMultipleComponent] public class AimPositionProv : EcsProvider<AimPosition> { }

  [Serializable]
  public struct AimPosition {
    public Vector3 value;
  }
}