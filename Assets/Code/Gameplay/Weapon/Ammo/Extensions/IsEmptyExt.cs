namespace Weapon.Ammo.Extensions {
   public static class IsEmptyExt {
      public static bool IsEmpty(this Magazine magazine) => magazine.amount <= 0;

      public static bool IsEmpty(this Ammo ammo) => ammo.amount <= 0;
   }
}