using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Unit.Behavior.ECS.Comps {
   [Serializable]
   public struct Path {
      public int cornerIndex;

      private NavMeshPath _path;


      public bool      Exist           => _path != null && CornersCount > 0;
      public Vector3[] Corners         => _path.corners;
      public int       CornersCount    => Corners.Length;
      public int       MaxIndex        => CornersCount - 1;
      public int       NextCornerIndex => Mathf.Min(cornerIndex + 1, MaxIndex);

      public NavMeshPath Value {
         get => _path ??= new NavMeshPath();
         set {
            _path       = value;
            cornerIndex = 0;
         }
      }

      public void End() => _path.ClearCorners();


      public Vector3 MoveDirection(Vector3 from) => Exist ? (NextCorner() - from).normalized : default;
      public Vector3 Corner()                    => Exist ? Corners[cornerIndex] : default;
      public Vector3 NextCorner()                => Exist ? Corners[NextCornerIndex] : default;
   }
}