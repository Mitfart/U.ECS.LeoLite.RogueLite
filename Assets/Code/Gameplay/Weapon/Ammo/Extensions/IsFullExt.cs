using Gameplay.Weapon.Ammo.Comps;

namespace Gameplay.Weapon.Ammo.Extensions {
   public static class IsFullExt {
      public static bool IsFull(this Magazine magazine) => magazine.amount == magazine.size;

      public static bool IsFull(this Comps.Ammo ammo) => ammo.amount == ammo.size;
   }
}