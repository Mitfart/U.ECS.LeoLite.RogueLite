using System;
using UnityEngine;

namespace ECS.UnityRef {
   [Serializable]
   public struct URefTransform : IEcsURef<Transform> {
      [field: SerializeField] public Transform Component { get; set; }
   }
}