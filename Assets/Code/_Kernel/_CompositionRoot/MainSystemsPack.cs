using Engine.Ecs;
using Events;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UnityIntegration;
using Mitfart.LeoECSLite.UnityIntegration.Name;
using Movement;
using Player;
using UnityRef;

public class MainSystemsPack : EcsSystemsPack {
  protected override void RegisterSystems() {
    Add<ConvertSceneSys>();
    AddPack<GetUnityDataSystems>();
    
    AddPack<PlayerSystems>();

    AddPack<MovementSystems>();
    AddPack<SetUnityDataSystems>();

    AddPack<ClearEventsPack>();

    AddWorldsDebug();
  }

  private void AddWorldsDebug() {
#if UNITY_EDITOR
    AddByInstance(new EcsWorldDebugSystem(nameSettings: new NameSettings(bakeComponents: true)));
#endif
  }
}