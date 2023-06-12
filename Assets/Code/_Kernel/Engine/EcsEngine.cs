using System.Collections.Generic;
using Engine.Ecs;
using Leopotam.EcsLite;

namespace Engine {
  public sealed class EcsEngine : IEngine {
    private readonly EscExtendedSystems _systems;

    private bool _enabled;



    public EcsEngine(EcsWorld world, IEnumerable<IEcsSystem> systems) {
      _systems = new EscExtendedSystems(world);
      AddSystems(systems);
    }


// @formatter:off
    public void Initialize() => _systems.Init();
    public void Tick()       { if (_enabled) _systems.Run(); }
    public void FixedTick()  { if (_enabled) _systems.FixedRun(); }
    public void Dispose()    => _systems.Destroy();

    public void Start() => _enabled = true;
    public void Stop()  => _enabled = false;
// @formatter:on



    private void AddSystems(IEnumerable<IEcsSystem> systems) {
      foreach (IEcsSystem system in systems)
        _systems.Add(system);
    }
  }
}