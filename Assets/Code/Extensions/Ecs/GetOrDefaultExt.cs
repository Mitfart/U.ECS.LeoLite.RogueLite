using Leopotam.EcsLite;

namespace Extensions.Ecs {
  public static class GetOrDefaultExt {
    public static TComp GetOrDefault<TComp>(this EcsPackedEntity packedEntity, EcsWorld world) where TComp : struct
      => packedEntity.Unpack(world, out int e)
        ? world.GetPool<TComp>().Get(e)
        : default;

    public static TComp GetOrDefault<TComp>(this EcsPackedEntityWithWorld packedEntity) where TComp : struct
      => packedEntity.Unpack(out EcsWorld world, out int e)
        ? world.GetPool<TComp>().Get(e)
        : default;
  }
}