using Leopotam.EcsLite;

namespace Features.Battle.Extensions {
  public static class PartakersAliveExt {
    public static bool TakerAlive(this  HitEvent hitEvent, out int takerE)  => hitEvent.Taker.Unpack(out EcsWorld _, out takerE);
    public static bool DealerAlive(this HitEvent hitEvent, out int dealerE) => hitEvent.Dealer.Unpack(out EcsWorld _, out dealerE);
  }
}