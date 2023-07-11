using System;
using UnityEngine;

namespace Structs.Ranged {
  [AttributeUsage(AttributeTargets.Field)]
  public class RangeEdgesAttribute : PropertyAttribute {
    public readonly float Max;
    public readonly float Min;

    public RangeEdgesAttribute(float min, float max) {
      Min = min < max ? min : max;
      Max = max > min ? max : min;
    }
  }
}