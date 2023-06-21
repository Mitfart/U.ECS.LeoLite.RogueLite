using System;
using UnityEngine;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace ECS.Unit.Comps {
  [DisallowMultipleComponent]
  public class ViewRadiusProv : EcsProvider<ViewRadius> {
    private void OnDrawGizmos() {
      Gizmos.color = Color.cyan;
      Gizmos.DrawWireSphere(transform.position, component.value);
    }
  }

  [Serializable]
  public struct ViewRadius {
    public float value;
  }
}