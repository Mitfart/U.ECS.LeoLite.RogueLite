using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Weapon._base {
   [DisallowMultipleComponent] public class WeaponTagProv : EcsProvider<WeaponTag> { }

   [Serializable] public struct WeaponTag { }
}