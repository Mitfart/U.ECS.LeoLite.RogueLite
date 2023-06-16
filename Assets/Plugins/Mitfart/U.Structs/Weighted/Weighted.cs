using System;
using UnityEngine;

namespace Structs.Weighted {
  [Serializable]
  public struct Weighted<T> {
    [SerializeField] private T     value;
    [SerializeField] private float weight;

    public T     Value  => value;
    public float Weight => weight;

    public Weighted(T value, float weight) {
      this.value  = value;
      this.weight = weight;
    }
  }
}