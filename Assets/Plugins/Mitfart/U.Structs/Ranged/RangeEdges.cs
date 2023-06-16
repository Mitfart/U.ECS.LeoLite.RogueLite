using System;
using UnityEngine;

namespace Structs.Ranged {
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
  public class RangeEdges : PropertyAttribute {
    public readonly float Max;
    public readonly float Min;

    public RangeEdges(float min, float max) {
      Min = min < max ? min : max;
      Max = max > min ? max : min;
    }
  }
}