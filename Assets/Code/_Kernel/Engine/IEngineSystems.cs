using System;
using Leopotam.EcsLite;
using VContainer.Unity;

namespace Engine {
   public interface IEngineSystems : IEcsSystems, IInitializable, IDisposable {
      void FixedRun();
   }
}