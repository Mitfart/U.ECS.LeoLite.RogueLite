using Battle;
using Engine.Ecs;
using Events;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UnityIntegration;
using Mitfart.LeoECSLite.UnityIntegration.Name;
using Movement;
using Player;
using UnityRef;
using Weapon;

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
    var nameSettings = new NameSettings(true);
    AddByInstance(new EcsWorldDebugSystem(nameSettings: nameSettings));
#endif
  }
}