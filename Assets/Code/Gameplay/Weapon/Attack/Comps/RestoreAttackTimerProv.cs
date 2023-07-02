using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Weapon.Attack.Comps {
   [DisallowMultipleComponent] public class RestoreAttackTimerProv : EcsProvider<RestoreAttackTimer> { }

   [Serializable]
   public struct RestoreAttackTimer {
      public float duration;

      [HideInInspector] public float startTime;
   }
}