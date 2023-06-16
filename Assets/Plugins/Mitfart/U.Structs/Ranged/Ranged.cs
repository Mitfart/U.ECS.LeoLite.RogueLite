using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Structs.Ranged {
  [Serializable]
  public struct Ranged {
    [SerializeField] private float min;
    [SerializeField] private float max;
    [SerializeField] private bool  rounded;
    [SerializeField] private float minEdge;
    [SerializeField] private float maxEdge;

    public float Min     => min;
    public float Max     => max;
    public bool  Rounded => rounded;
    public float MinEdge => minEdge;
    public float MaxEdge => maxEdge;


    public Ranged(float minV, float maxV, bool rounded = false) {
      min          = minV < maxV ? minV : maxV;
      max          = maxV > minV ? maxV : minV;
      this.rounded = rounded;
      minEdge      = Mathf.Min(0f, min);
      maxEdge      = Mathf.Max(1f, max);
    }

    public Ranged(
      float minV,
      float maxV,
      float maxMinV,
      float maxMaxV,
      bool  rounded = false
    ) : this(
      minV,
      maxV,
      rounded
    ) {
      minEdge = Mathf.Min(maxMinV, min);
      maxEdge = Mathf.Max(maxMaxV, max);
    }


    public float Clamp(float value) => Mathf.Clamp(value, Min, Max);
    public int   Clamp(int   value) => Mathf.RoundToInt(Clamp((float) value));

    public float GetRandom()    => Random.Range(Min, Max);
    public int   GetRandomInt() => Mathf.RoundToInt(GetRandom());


    public override string ToString() => $"Value: ({Min}, {Max}),  Edges: ({MinEdge}, {MaxEdge})";
  }
}