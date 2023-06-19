using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Features.Player {
  [DisallowMultipleComponent] public class PlayerTagProv : EcsProvider<PlayerTag> { }

  [Serializable] public struct PlayerTag { }
}