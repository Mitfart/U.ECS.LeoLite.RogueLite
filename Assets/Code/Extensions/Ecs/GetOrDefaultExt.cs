using Leopotam.EcsLite;

namespace Extensions.Ecs {
  public static class GetOrDefaultExt {
    public static TComp GetOrDefault<TComp>(this EcsPackedEntity packedEntity, EcsWorld world, TComp def = default) where TComp : struct //
      => packedEntity.GetOrNull<TComp>(world) ?? def;

    public static TComp GetOrDefault<TComp>(this EcsPackedEntityWithWorld packedEntity, TComp def = default) where TComp : struct //
      => packedEntity.GetOrNull<TComp>() ?? def;



    public static TComp? GetOrNull<TComp>(this EcsPackedEntity packedEntity, EcsWorld world) where TComp : struct
      => packedEntity.Unpack(world, out int e)
        ? world.GetPool<TComp>().Get(e)
        : null;

    public static TComp? GetOrNull<TComp>(this EcsPackedEntityWithWorld packedEntity) where TComp : struct
      => packedEntity.Unpack(out EcsWorld world, out int e)
        ? world.GetPool<TComp>().Get(e)
        : null;
  }
}