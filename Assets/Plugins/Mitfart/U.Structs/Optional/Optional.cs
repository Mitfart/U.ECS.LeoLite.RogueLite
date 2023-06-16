using System;
using UnityEngine;

namespace Structs.Optional {
  [Serializable]
  public struct Optional<T> {
    [SerializeField] private T    value;
    [SerializeField] private bool enabled;

    public bool Enabled => enabled;
    public T    Value   => value;

    public Optional(T value, bool enabled = true) {
      this.enabled = enabled;
      this.value   = value;
    }
  }
}