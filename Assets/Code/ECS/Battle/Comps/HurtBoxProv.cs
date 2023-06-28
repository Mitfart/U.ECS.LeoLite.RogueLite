using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace ECS.Battle {
   [DisallowMultipleComponent] public class HurtBoxProv : EcsProvider<HurtBox> { }

   [Serializable]
   public struct HurtBox {
      [field: SerializeField] public Collider2D Collider { get; private set; }
   }
}