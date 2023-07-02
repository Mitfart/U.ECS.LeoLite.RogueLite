using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Player.Comps {
   [DisallowMultipleComponent] public class PlayerTagProv : EcsProvider<PlayerTag> { }

   [Serializable] public struct PlayerTag { }
}