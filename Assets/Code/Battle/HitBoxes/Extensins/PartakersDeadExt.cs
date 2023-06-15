using Leopotam.EcsLite;

namespace Battle.HitBoxes.Extensins {
  public static class PartakersDeadExt {
    public static bool TakerDead(this  HitEvent hitEvent, EcsWorld world, out int takerE)  => !hitEvent.Taker.Unpack(world, out takerE);
    public static bool DealerDead(this HitEvent hitEvent, EcsWorld world, out int dealerE) => !hitEvent.Dealer.Unpack(world, out dealerE);
  }
}