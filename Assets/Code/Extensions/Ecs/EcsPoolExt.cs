using Leopotam.EcsLite;

namespace Extensions.Ecs {
   public static class EcsPoolExt {
      public static void TryAdd<T>(this EcsPool<T> pool, int e, T value = default) where T : struct {
         if (!pool.Has(e))
            pool.Add(e) = value;
      }

      public static void TryDel<T>(this EcsPool<T> pool, int e) where T : struct {
         if (pool.Has(e))
            pool.Del(e);
      }

      public static bool TryGet<T>(this EcsPool<T> pool, int e, out T value) where T : struct {
         if (pool.Has(e)) {
            value = pool.Get(e);
            return true;
         }

         value = default;
         return false;
      }



      public static ref T GetOrAdd<T>(this EcsPool<T> pool, int e) where T : struct {
         if (pool.Has(e))
            return ref pool.Get(e);

         return ref pool.Add(e);
      }



      public static ref T Set<T>(this EcsPool<T> pool, int e, T value = default) where T : struct {
         if (pool.Has(e))
            pool.Del(e);

         pool.Add(e) = value;
         return ref pool.Get(e);
      }
   }
}