﻿using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Player {
  [DisallowMultipleComponent] public class PlayerTagProv : EcsProvider<PlayerTag> { }

  [Serializable] public struct PlayerTag { }
}