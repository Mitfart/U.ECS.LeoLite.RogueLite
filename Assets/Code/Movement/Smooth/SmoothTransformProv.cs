﻿using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Movement.Smooth {
  [DisallowMultipleComponent] public class SmoothTransformProv : EcsProvider<SmoothTransform> { }

  [Serializable]
  public struct SmoothTransform {
    public SmoothVector3 value;
  }
}