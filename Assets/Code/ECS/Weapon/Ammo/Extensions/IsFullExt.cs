namespace ECS.Weapon.Ammo.Extensions {
   public static class IsFullExt {
      public static bool IsFull(this Magazine magazine) {
         return magazine.amount == magazine.size;
      }

      public static bool IsFull(this Ammo ammo) {
         return ammo.amount == ammo.size;
      }
   }
}