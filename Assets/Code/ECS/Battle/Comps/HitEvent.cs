using System;
using Events;
using UnityEngine;

namespace ECS.Battle {
   [Serializable]
   public struct HitEvent : IEvent {
      public int     dealer;
      public int     taker;
      public Vector3 point;
      public Vector3 normal;
      public float   damage;

      public override string ToString() => $"Dealer: {dealer} > Taker: {taker} | Damage: {damage} [point: {point}, normal: {normal}]";
   }
}