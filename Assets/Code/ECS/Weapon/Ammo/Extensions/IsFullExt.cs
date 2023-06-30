namespace ECS.Weapon.Ammo.Extensions {
   public static class IsFullExt {
      public static bool IsFull(this Magazine magazine) => magazine.amount == magazine.size;

      public static bool IsFull(this Ammo ammo) => ammo.amount == ammo.size;
   }
}