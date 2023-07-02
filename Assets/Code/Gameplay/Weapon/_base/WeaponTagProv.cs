using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Weapon {
   [DisallowMultipleComponent] public class WeaponTagProv : EcsProvider<WeaponTag> { }

   [Serializable] public struct WeaponTag { }
}