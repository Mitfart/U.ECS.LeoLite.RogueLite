using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Level {
   public class SpawnPoint : MonoBehaviour {
      [field: SerializeField] public ConvertToEntity Enemy { get; private set; }

      public Vector3 Position => transform.position;
   }
}