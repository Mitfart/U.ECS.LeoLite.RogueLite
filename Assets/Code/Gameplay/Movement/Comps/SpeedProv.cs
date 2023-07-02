using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Movement.Comps {
   [DisallowMultipleComponent] public class SpeedProv : EcsProvider<Speed> { }

   [Serializable]
   public struct Speed {
      public float value;
   }
}