using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;
using UnityRef.Transform.Extras.Direction;

namespace Movement {
  [DisallowMultipleComponent] public class DirectionInputProv : EcsProvider<DirectionInput> { }

  [Serializable]
  public struct DirectionInput {
    public Direction value;
  }
}