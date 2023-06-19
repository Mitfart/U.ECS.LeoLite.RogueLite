using System;
using Events;
using Leopotam.EcsLite;
using UnityEngine;

namespace Features.Battle {
  [Serializable]
  public struct HitEvent : IEvent {
    public float damage;

    public Vector3                  point;
    public Vector3                  normal;
    public EcsPackedEntityWithWorld Dealer;
    public EcsPackedEntityWithWorld Taker;
  }
}