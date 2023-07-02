using System.Collections.Generic;
using Engine.Ecs;
using Leopotam.EcsLite;

namespace Engine {
   public sealed class EcsEngine : IEngine {
      private readonly EscExtendedSystems _systems;

      public bool Enabled { get; private set; }



      public EcsEngine(EcsWorld world, IEnumerable<IEcsSystem> systems) {
         _systems = new EscExtendedSystems(world);
         AddSystems(systems);
      }



      public void Initialize() => _systems.Init();
      public void Dispose()    => _systems.Destroy();

      public void Tick() {
         if (Enabled)
            _systems.Run();
      }

      public void FixedTick() {
         if (Enabled)
            _systems.FixedRun();
      }

      public void Enable()  => Enabled = true;
      public void Disable() => Enabled = false;



      private void AddSystems(IEnumerable<IEcsSystem> systems) {
         foreach (IEcsSystem system in systems) {
            _systems.Add(system);
         }
      }
   }
}