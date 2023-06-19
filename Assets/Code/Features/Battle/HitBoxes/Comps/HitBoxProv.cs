using System;
using Features.Battle.Extensions;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Features.Battle.HitBoxes {
  [DisallowMultipleComponent]
  public class HitBoxProv : EcsProvider<HitBox> {
    private void OnDrawGizmosSelected() {
      component.Area.DrawGizmos(transform.localToWorldMatrix, Color.red);
    }
  }

  [Serializable]
  public struct HitBox {
    [field: SerializeField] public Area      Area      { get; private set; }
    [field: SerializeField] public LayerMask LayerMask { get; private set; }
  }
}