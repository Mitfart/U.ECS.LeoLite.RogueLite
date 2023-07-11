using System;
using UnityEngine;

namespace Structs.Ranged {
   [Serializable]
   public class Ranged {
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


      public Ranged(float min, float max, bool rounded = false) : this(
         min,
         max,
         Mathf.Min(0f, min),
         Mathf.Max(1f, max),
         rounded
      ) { }

      public Ranged(
         float min,
         float max,
         float minEdge,
         float maxEdge,
         bool  rounded = false
      ) {
         this.min = min < max ? min : max;
         this.max = max > min ? max : min;

         this.minEdge = Mathf.Min(minEdge, this.min);
         this.maxEdge = Mathf.Max(maxEdge, this.max);

         this.rounded = rounded;
      }


      public float Clamp(float value) => Mathf.Clamp(value, Min, Max);
      public int   Clamp(int   value) => Mathf.RoundToInt(Clamp((float)value));

      public float Random()    => UnityEngine.Random.Range(Min, Max);
      public int   RandomInt() => Mathf.RoundToInt(Random());


      public override string ToString() => $"Value: ({Min}, {Max}),  Edges: ({MinEdge}, {MaxEdge})";
   }
}