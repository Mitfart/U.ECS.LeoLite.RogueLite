using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Features.Destroy {
  [DisallowMultipleComponent] public class DestroyProv : EcsProvider<Destroy> { }

  [Serializable] public struct Destroy { }
}