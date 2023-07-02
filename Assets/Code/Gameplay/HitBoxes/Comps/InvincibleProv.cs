﻿using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace HitBoxes {
   [DisallowMultipleComponent] public class InvincibleProv : EcsProvider<Invincible> { }

   [Serializable]
   public struct Invincible {
      public float duration;

      [HideInInspector] public float startTime;

      public Invincible(float duration) {
         this.duration = duration;
         startTime     = Time.time;
      }
   }
}