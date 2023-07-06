using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Unit.Behavior {
   public interface IAINavService {
      public bool CalcPath(Vector3 start, Vector3 end, NavMeshPath path);
   }
}