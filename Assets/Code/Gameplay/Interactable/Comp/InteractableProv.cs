using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Interactable {
   [DisallowMultipleComponent] public class InteractableProv : EcsProvider<Interactable> { }

   [Serializable] public struct Interactable { }
}