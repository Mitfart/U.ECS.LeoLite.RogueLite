using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Unit.Behavior.ECS.Comps {
   [Serializable]
   public struct Path {
      public int cornerIndex;

      private NavMeshPath _path;


      public Vector3[] Corners         => Value.corners;
      public int       CornersCount    => Corners.Length;
      public bool      Exist           => CornersCount > 0;
      public int       MaxIndex        => CornersCount - 1;
      public bool      Completed       => cornerIndex == MaxIndex;
      public int       NextCornerIndex => Mathf.Min(cornerIndex + 1, MaxIndex);

      public NavMeshPath Value {
         get => _path ??= new NavMeshPath();
         set {
            _path       = value;
            cornerIndex = 0;
         }
      }


      public Vector3 Corner()     => Exist ? Corners[cornerIndex] : default;
      public Vector3 NextCorner() => Exist ? Corners[NextCornerIndex] : default;
   }
}