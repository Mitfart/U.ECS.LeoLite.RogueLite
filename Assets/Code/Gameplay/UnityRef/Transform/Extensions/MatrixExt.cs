﻿using Gameplay.UnityRef.Transform.Comp;
using UnityEngine;

namespace Gameplay.UnityRef.Transform.Extensions {
   public static class MatrixExt {
      public static Matrix4x4 Matrix(this ref EcsTransform t) => Matrix4x4.TRS(t.Position, t.Rotation, Vector3.one * t.Scale);
   }
}