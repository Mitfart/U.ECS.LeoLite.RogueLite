using System;
using UnityEngine;
using UnityRef;

namespace Physics {
  [DisallowMultipleComponent]
  [RequireComponent(typeof(Rigidbody2D))]
  public class Rigidbody2DURefProv : EcsUnityURefProv<Rigidbody2D, Rigidbody2DRef> { }

  [Serializable]
  public struct Rigidbody2DRef : IEcsURef<Rigidbody2D> {
    [field: SerializeField] public Rigidbody2D Component { get; set; }
  }
}