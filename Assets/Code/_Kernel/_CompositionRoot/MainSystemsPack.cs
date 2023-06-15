using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UnityIntegration;
using Mitfart.LeoECSLite.UnityIntegration.Name;
using Engine.Ecs;
using UnityRef;
using Events;
using Player;
using Battle;
using Battle.Weapon;
using Movement;

public class MainSystemsPack : EcsSystemsPack {
  protected override void RegisterSystems() {
    Add<ConvertSceneSys>();
    AddPack<GetUnityDataSystems>();

    AddPack<PlayerSystems>();
    AddPack<MovementSystems>();
    AddPack<WeaponSystems>();
    AddPack<BattleSystems>();

    AddPack<SetUnityDataSystems>();
    AddPack<ClearEventsPack>();

    AddWorldsDebug();
  }

  private void AddWorldsDebug() {
#if UNITY_EDITOR
    var nameSettings = new NameSettings(bakeComponents: true);
    AddByInstance(new EcsWorldDebugSystem(nameSettings: nameSettings));
#endif
  }
}