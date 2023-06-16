using System;
using UnityEngine;

namespace Structs.Counted {
  [Serializable]
  public struct Counted<T> {
    [SerializeField] private T   value;
    [SerializeField] private int count;

    public T   Value => value;
    public int Count => count;

    public Counted(T value, int count) {
      this.value = value;
      this.count = count;
    }
  }
}