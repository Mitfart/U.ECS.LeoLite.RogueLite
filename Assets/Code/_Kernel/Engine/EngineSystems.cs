using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Engine {
   public class EngineSystems : EcsSystems, IEngineSystems {
      private readonly IEnumerable<IEcsSystem> _rawSystems;

      private readonly List<IEcsFixedRunSystem> _fixedRunSystems;



      public EngineSystems(EcsWorld world, IEnumerable<IEcsSystem> rawSystems) : base(world) {
         _rawSystems      = rawSystems;
         _fixedRunSystems = new List<IEcsFixedRunSystem>();
      }

      public void Initialize() {
         foreach (IEcsSystem system in _rawSystems) {
            Add(system);
         }

         Init();
      }

      public void Dispose() => Destroy();



      public void FixedRun() {
         foreach (IEcsFixedRunSystem system in _fixedRunSystems) {
            system.FixedRun(this);
         }
      }



      public override IEcsSystems Add(IEcsSystem system) {
         base.Add(system);

         if (system is IEcsFixedRunSystem fixedRunSystem)
            _fixedRunSystems.Add(fixedRunSystem);

         return this;
      }
   }
}