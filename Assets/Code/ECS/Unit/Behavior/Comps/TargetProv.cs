using System;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace ECS.Unit.Behavior.Comps {
   [DisallowMultipleComponent] public class TargetProv : EcsProvider<Target> { }

   [Serializable]
   public struct Target {
      public EcsPackedEntityWithWorld Value;
   }
}