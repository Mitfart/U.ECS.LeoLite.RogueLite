using System.Collections.Generic;
using Engine.Ecs;
using Leopotam.EcsLite;

namespace Engine {
   public sealed class EcsEngine : IEngine {
      private readonly EscExtendedSystems _systems;



      public EcsEngine(EcsWorld world, IEnumerable<IEcsSystem> systems) {
         _systems = new EscExtendedSystems(world);
         AddSystems(systems);
      }



      public void Init()     => _systems.Init();
      public void Run()      => _systems.Run();
      public void FixedRun() => _systems.FixedRun();
      public void Dispose()  => _systems.Destroy();



      private void AddSystems(IEnumerable<IEcsSystem> systems) {
         foreach (IEcsSystem system in systems) {
            _systems.Add(system);
         }
      }
   }
}