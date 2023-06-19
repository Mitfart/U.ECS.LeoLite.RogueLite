using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Features.Movement.Character {
  [CreateAssetMenu(fileName = "new PhysicsMovement params", menuName = "SCR/Movement/new PhysicsMovement params")]
  public class ScrPhysicsMovement : ScrComponent<CharacterMovement> { }

  [Serializable]
  public struct CharacterMovement {
    [field: SerializeField] public float          Speed             { get; private set; }
    [field: SerializeField] public float          Accel             { get; private set; }
    [field: SerializeField] public float          MaxAccel          { get; private set; }
    [field: SerializeField] public AnimationCurve AccelDotFactor    { get; private set; }
    [field: SerializeField] public AnimationCurve MaxAccelDotFactor { get; private set; }
    [field: SerializeField] public float          Scale             { get; private set; }
  }
}