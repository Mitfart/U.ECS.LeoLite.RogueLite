using System;
using UnityEngine;
using UnityRef;

namespace Extras.Direction.Extensions {
  public static class DirectionExt {
    public static Vector3 GetDirection(this EcsTransform ecsTransform, Direction direction) {
      return direction switch {
        Direction.Up    => ecsTransform.Up,
        Direction.Down  => -ecsTransform.Up,
        Direction.Right => ecsTransform.Right,
        Direction.Left  => -ecsTransform.Right,
        _               => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
      };
    }

    public static Vector3 GetVector(Direction direction) {
      return direction switch {
        Direction.Up    => Vector3.up,
        Direction.Down  => -Vector3.up,
        Direction.Right => Vector3.right,
        Direction.Left  => -Vector3.right,
        _               => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
      };
    }
  }
}