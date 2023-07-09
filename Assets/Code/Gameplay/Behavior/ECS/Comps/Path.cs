using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Unit.Behavior.ECS.Comps {
   [Serializable]
   public struct Path {
      public int   cornerIndex;
      public bool  exist;

      private NavMeshPath _path;

      public Vector3[] Corners         => _path.corners;
      public int       CornersCount    => Corners.Length;
      public int       MaxIndex        => CornersCount - 1;
      public int       NextCornerIndex => Mathf.Min(cornerIndex + 1, MaxIndex);



      public bool Calc(IAINavService navService, Vector3 start, Vector3 end) {
         _path ??= new NavMeshPath();

         cornerIndex = 0;

         return exist = navService.CalcPath(start, end, _path);
      }



      public Vector3 MoveDirection(Vector3 from) => exist ? (NextCorner() - from).normalized : default;
      public Vector3 Corner()                    => exist ? Corners[cornerIndex] : default;
      public Vector3 NextCorner()                => exist ? Corners[NextCornerIndex] : default;
   }
}