using System;
using Events;
using Leopotam.EcsLite;
using UnityEngine;

namespace Battle.HitBoxes {
  [Serializable]
  public struct HitEvent : IEvent {
    public EcsPackedEntity Dealer;
    public EcsPackedEntity Taker;
    public Vector3         Point;
    public Vector3         Normal;
  }
}