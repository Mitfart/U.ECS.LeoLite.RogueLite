using System;
using Leopotam.EcsLite;
using VContainer.Unity;

namespace Engine.Ecs {
   public interface IEngineSystems : IEcsSystems, IInitializable, IDisposable  {
      void FixedRun();
   }
}