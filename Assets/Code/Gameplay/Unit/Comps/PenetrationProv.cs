﻿using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Unit.Comps {
   [DisallowMultipleComponent] public class PenetrationProv : EcsProvider<Penetration> { }

   [Serializable]
   public struct Penetration {
      public int amount;

      [HideInInspector] public int elapsedCount;
   }
}