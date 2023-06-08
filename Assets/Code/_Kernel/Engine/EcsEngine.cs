using System.Collections.Generic;
using Extentions;
using Leopotam.EcsLite;

namespace Engine {
  public sealed class EcsEngine : IEngine {
    private readonly EscExtendedSystems _systems;



    public EcsEngine(IEnumerable<IEcsSystem> systems) {
      var world = new EcsWorld();
      _systems = new EscExtendedSystems(world);

      UnityEngine.Debug.Log("Systems??");
      foreach (IEcsSystem system in systems) 
        _systems.Add(system);
    }


    public void Initialize() => _systems.Init();
    public void Tick()       => _systems.Run();
    public void FixedTick()  => _systems.FixedRun();
    public void Dispose()    => _systems.Destroy();
  }
}