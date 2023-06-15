using System;
using UnityEngine;

namespace Battle.HitBoxes {
  [Serializable]
  public struct Area {
    public Vector3 size;
    public Vector3 origin;

    public override string ToString() => $"[size: {size}, origin: {origin}]";
  }
}