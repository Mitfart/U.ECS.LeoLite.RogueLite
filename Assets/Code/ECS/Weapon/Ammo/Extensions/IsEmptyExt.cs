using Features.Weapon.Ammo._base;

namespace Features.Weapon.Ammo.Extensions {
  public static class IsEmptyExt {
    public static bool IsEmpty(this Magazine magazine) => magazine.amount <= 0;

    public static bool IsEmpty(this _base.Ammo ammo) => ammo.amount <= 0;
  }
}