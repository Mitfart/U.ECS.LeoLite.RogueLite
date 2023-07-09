using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Unit.Behavior {
   public sealed class AINavService : MonoBehaviour, IAINavService {
      [SerializeField] private NavMeshAgent agent;



      public bool CalcPath(Vector3 start, Vector3 end, NavMeshPath path)
         => agent.Warp(start)
         && agent.CalculatePath(end, path);
   }
}