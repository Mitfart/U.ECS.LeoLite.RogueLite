using System;
using Gameplay.UnityRef.Transform.Comp;
using Gameplay.UnityRef.Transform.Extensions;
using UnityEngine;

namespace Gameplay.Movement.Direction.Extensions {
   public static class DirectionExt {
      public static Vector3 GetDirection(this EcsTransform ecsTransform, Direction direction)
         => direction switch {
            Direction.Up    => ecsTransform.Up(),
            Direction.Down  => -ecsTransform.Up(),
            Direction.Right => ecsTransform.Right(),
            Direction.Left  => -ecsTransform.Right(),
            _               => throw new ArgumentOutOfRangeException(nameof(direction), direction, message: null)
         };

      public static Vector3 GetVector(this Direction direction)
         => direction switch {
            Direction.Up    => Vector3.up,
            Direction.Down  => -Vector3.up,
            Direction.Right => Vector3.right,
            Direction.Left  => -Vector3.right,
            _               => throw new ArgumentOutOfRangeException(nameof(direction), direction, message: null)
         };
   }
}