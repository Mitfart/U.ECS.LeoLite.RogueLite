using System;
using Events;
using UnityEngine;

namespace Gameplay.HitBoxes.Comps {
   [Serializable]
   public struct HitEvent : IEvent {
      public int     dealer;
      public int     taker;
      public Vector3 point;
      public Vector3 normal;

      public override string ToString() => $"Dealer: {dealer} > Taker: {taker} [point: {point}, normal: {normal}]";
   }
}