using Features.Weapon.Ammo._base;

namespace Features.Weapon.Ammo.Extensions {
  public static class IsFullExt {
    public static bool IsFull(this Magazine magazine) => magazine.amount == magazine.size;

    public static bool IsFull(this _base.Ammo ammo) => ammo.amount == ammo.size;
  }
}