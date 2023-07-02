using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Movement.Comps {
   [DisallowMultipleComponent] public class DirectionInputProv : EcsProvider<DirectionInput> { }

   [Serializable]
   public struct DirectionInput {
      public Direction.Direction value;
   }
}