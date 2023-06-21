using System;
using Leopotam.EcsLite;
using UnityEngine;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace ECS.Unit.Comps {
  [DisallowMultipleComponent] public class TargetProv : EcsProvider<Target> { }

  [Serializable]
  public struct Target {
    public EcsPackedEntityWithWorld target;
  }
}