using Gameplay.Weapon.Ammo.Comps;

namespace Gameplay.Weapon.Ammo.Extensions {
   public static class IsEmptyExt {
      public static bool IsEmpty(this Magazine magazine) => magazine.amount <= 0;

      public static bool IsEmpty(this Comps.Ammo ammo) => ammo.amount <= 0;
   }
}