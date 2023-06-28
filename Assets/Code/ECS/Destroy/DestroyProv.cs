using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace ECS.Destroy {
   [DisallowMultipleComponent] public class DestroyProv : EcsProvider<Destroy> { }

   [Serializable] public struct Destroy { }
}