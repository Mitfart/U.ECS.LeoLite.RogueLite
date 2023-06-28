using System;
using ECS.Battle.Extensions;
using ECS.Battle.Structs;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace ECS.Battle {
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