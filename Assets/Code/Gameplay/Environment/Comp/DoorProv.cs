using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Level {
   [DisallowMultipleComponent] public class DoorProv : EcsProvider<Door> { }

   [Serializable]
   public struct Door {
      public NextLevel NextLevel;
   }
}