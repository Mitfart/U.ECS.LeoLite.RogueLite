using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Engine.Ecs {
   public class EscExtendedSystems : EcsSystems {
      private readonly List<IEcsFixedRunSystem> _fixedRunSystems;



      public EscExtendedSystems(EcsWorld defaultWorld, object shared = null) : base(defaultWorld, shared) {
         _fixedRunSystems = new List<IEcsFixedRunSystem>();
      }


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