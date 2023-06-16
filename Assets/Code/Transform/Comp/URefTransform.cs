using System;
using UnityEngine;
using UnityRef;

[Serializable]
public struct URefTransform : IEcsURef<Transform> {
  [field: SerializeField] public Transform Component { get; set; }
}