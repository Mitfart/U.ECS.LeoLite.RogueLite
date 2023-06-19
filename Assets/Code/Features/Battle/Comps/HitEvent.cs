using System;
using Events;
using Leopotam.EcsLite;
using UnityEngine;

namespace Features.Battle {
  [Serializable]
  public struct HitEvent : IEvent {
    public int     dealer;
    public int     taker;
    public Vector3 point;
    public Vector3 normal;
    public float   damage;
  }
}