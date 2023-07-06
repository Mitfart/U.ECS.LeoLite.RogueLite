using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Unit.Behavior.ECS.Comps {
   [Serializable]
   public struct Path {
      public NavMeshPath Value;
      public int         cornerIndex;
      public bool        exist;

      public Vector3[] Corners         => Value.corners;
      public int       CornersCount    => Corners.Length;
      public int       MaxIndex        => exist ? CornersCount - 1 : 0;
      public int       NextCornerIndex => Mathf.Min(cornerIndex + 1, MaxIndex);



      public bool Calc(IAINavService navService, Vector3 start, Vector3 end) {
         Value ??= new NavMeshPath();

         cornerIndex = 0;

         return exist = navService.CalcPath(
            start,
            end,
            Value
         );
      }



      public Vector3 MoveDirection() => exist ? (NextCorner() - Corner()).normalized : default;
      public Vector3 Corner()        => Corners[cornerIndex];
      public Vector3 NextCorner()    => Corners[NextCornerIndex];
   }
}