using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Movement {
  [DisallowMultipleComponent] public class MoveDirectionProv : EcsProvider<MoveDirection> { }

  [Serializable]
  public struct MoveDirection {
    public Vector3 value;
  }
}