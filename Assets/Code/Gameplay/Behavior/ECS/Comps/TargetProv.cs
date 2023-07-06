using System;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Unit.Behavior.ECS.Comps {
   [DisallowMultipleComponent] public class TargetProv : EcsProvider<Target> { }

   [Serializable]
   public struct Target {
      public EcsPackedEntityWithWorld Value;
   }
}