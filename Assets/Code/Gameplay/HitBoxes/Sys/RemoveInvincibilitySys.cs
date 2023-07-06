using Gameplay.HitBoxes.Comps;
using Infrastructure.Services.Time;
using Leopotam.EcsLite;

namespace Gameplay.HitBoxes.Sys {
   public class RemoveInvincibilitySys : IEcsRunSystem, IEcsInitSystem {
      private readonly ITimeService _timeService;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Invincible> _invinciblePool;



      public RemoveInvincibilitySys(ITimeService timeService) {
         _timeService = timeService;
      }

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<Invincible>().End();

         _invinciblePool = _world.GetPool<Invincible>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            if (PassInvincibilityTime(e))
               MakeNotInvincible(e);
         }
      }



      private bool PassInvincibilityTime(int entity) => _timeService.Time - _invinciblePool.Get(entity).startTime > _invinciblePool.Get(entity).duration;
      private void MakeNotInvincible(int     entity) => _invinciblePool.Del(entity);
   }
}