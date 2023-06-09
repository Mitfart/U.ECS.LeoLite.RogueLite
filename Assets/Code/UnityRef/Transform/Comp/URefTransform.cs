using System;
using UnityEngine;

namespace UnityRef {
  [Serializable]
  public struct URefTransform : IEcsURef<UnityEngine.Transform> {
    [field: SerializeField] public UnityEngine.Transform Component { get; set; }
  }
}