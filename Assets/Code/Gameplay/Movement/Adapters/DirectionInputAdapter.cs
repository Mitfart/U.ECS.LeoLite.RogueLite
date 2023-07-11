using Gameplay.Movement.Comps;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Movement.Adapters {
   [RequireComponent(typeof(MovementAdapter))]
   public class DirectionInputAdapter : EcsAdapter<DirectionInput> { }
}