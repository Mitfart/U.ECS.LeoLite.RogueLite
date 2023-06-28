namespace ECS.Weapon.Ammo.Extensions {
   public static class IsEmptyExt {
      public static bool IsEmpty(this Magazine magazine) {
         return magazine.amount <= 0;
      }

      public static bool IsEmpty(this Ammo ammo) {
         return ammo.amount <= 0;
      }
   }
}