using Destroy;
using Engine.Ecs;
using Events;
using Gameplay.Interactable;
using HitBoxes;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UnityIntegration;
using Mitfart.LeoECSLite.UnityIntegration.Name;
using Movement;
using Player;
using Unit;
using UnityRef;
using View;
using Weapon;

public class MainSystemsPack : EcsSystemsPack {
   protected override void RegisterSystems() {
      Add<ConvertSceneSys>();
      AddPack<GetUnityDataSystems>();

      AddPack<PlayerSystems>();
      AddPack<MovementSystems>();
      AddPack<InteractableSystems>();
      AddPack<WeaponSystems>();
      AddPack<BattleSystems>();
      AddPack<UnitSystems>();

      AddPack<ViewSystems>();
      AddPack<SetUnityDataSystems>();
      AddPack<DestroySystems>();

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