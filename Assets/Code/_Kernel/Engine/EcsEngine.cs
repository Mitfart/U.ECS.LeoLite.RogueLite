using System;
using Engine.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UnityIntegration.Extensions;
using VContainer.Unity;

namespace Engine {
   public sealed class EcsEngine : IEngine, ITickable, IFixedTickable, IDisposable {
      private readonly EcsWorld       _world;
      private readonly IEngineSystems _systems;

      public bool Enabled { get; private set; }



      public EcsEngine(EcsWorld world, IEngineSystems systems) {
         _world   = world;
         _systems = systems;
      }



      public void Tick() {
         if (Enabled)
            _systems.Run();
      }

      public void FixedTick() {
         if (Enabled)
            _systems.FixedRun();
      }



      public void Dispose() => _systems.Dispose();

      public void Enable()  => Enabled = true;
      public void Disable() => Enabled = false;

      public void Clear() => _world.ForeachEntity(_world.DelEntity);
   }
}