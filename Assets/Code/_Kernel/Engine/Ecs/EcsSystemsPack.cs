using System;
using Leopotam.EcsLite;
using VContainer;

namespace Extentions {
  public abstract class EcsSystemsPack {
    private IContainerBuilder _di;



    public void Install(IContainerBuilder di) {
      _di = di;
      RegisterSystems();
    }

    protected abstract void RegisterSystems();



    protected void AddPack<TPack>() where TPack : EcsSystemsPack, new() {
      new TPack().Install(_di);
    }

    protected void Add<TSystem>() where TSystem : class, IEcsSystem {
      _di.Register<TSystem>(Lifetime.Transient)
         .AsSelf()
         .AsImplementedInterfaces();
    }

    protected void AddByInstance<TSystem>(TSystem instance) where TSystem : class, IEcsSystem {
      _di.Register(_ => instance, Lifetime.Transient)
         .AsSelf()
         .AsImplementedInterfaces();
    }

    protected void AddByConfiguration<TSystem>(Func<IObjectResolver, TSystem> configuration) where TSystem : class, IEcsSystem {
      _di.Register(configuration, Lifetime.Transient)
         .AsSelf()
         .AsImplementedInterfaces();
    }
  }
}