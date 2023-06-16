using Weapon.Ammo._base;

namespace Weapon.Ammo {
  public static class Ext {
    public static bool IsFull(this Magazine magazine) => magazine.amount == magazine.size;

    public static bool IsEmpty(this Magazine magazine) => magazine.amount <= 0;

    public static bool IsFull(this _base.Ammo ammo) => ammo.amount == ammo.size;

    public static bool IsEmpty(this _base.Ammo ammo) => ammo.amount <= 0;
  }
}