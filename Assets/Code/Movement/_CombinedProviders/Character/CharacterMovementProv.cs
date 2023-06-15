using Extensions.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Movement.Character {
  [DisallowMultipleComponent]
  public class CharacterMovementProv : EcsScrProvider<CharacterMovement, ScrPhysicsMovement> {
    public override void Convert(int e, EcsWorld world) {
      CharacterMovement p = scrComponent.GetComponent();

      world.GetPool<Speed>().Set(e, Speed(p));
      world.GetPool<PhysicsMovement>().Set(e, PhysicsMovement(p));
      world.GetPool<MoveDirection>().Set(e);

      Destroy(this);
    }



    private static Speed Speed(CharacterMovement v) => new() { value = v.Speed * v.Scale };

    private static PhysicsMovement PhysicsMovement(CharacterMovement v)
      => new() {
        Accel             = v.Accel    * v.Scale,
        MaxAccel          = v.MaxAccel * v.Scale,
        AccelDotFactor    = v.AccelDotFactor,
        MaxAccelDotFactor = v.MaxAccelDotFactor
      };
  }
}