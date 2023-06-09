﻿using Gameplay.View.Comps;
using Leopotam.EcsLite;

namespace Gameplay.View.Sys {
   public class RefreshViewSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Views> _viewsPool;

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<Views>().End();

         _viewsPool = _world.GetPool<Views>();
      }



      public void Run(IEcsSystems systems) {
         foreach (int e in _filter)
         foreach (EcsView view in _viewsPool.Get(e).value) {
            view.Refresh(_world, e);
         }
      }
   }
}