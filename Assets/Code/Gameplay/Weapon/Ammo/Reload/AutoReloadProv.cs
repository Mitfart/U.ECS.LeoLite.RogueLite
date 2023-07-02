using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Weapon.Ammo.Reload {
   [DisallowMultipleComponent] public class AutoReloadProv : EcsProvider<AutoReload> { }

   [Serializable] public struct AutoReload { }
}