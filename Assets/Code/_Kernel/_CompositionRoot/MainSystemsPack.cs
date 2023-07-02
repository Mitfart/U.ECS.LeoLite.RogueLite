using Engine.Ecs;
using Events;
using Gameplay.Destroy;
using Gameplay.HitBoxes;
using Gameplay.Level;
using Gameplay.Movement;
using Gameplay.Player;
using Gameplay.Unit;
using Gameplay.UnityRef;
using Gameplay.View;
using Gameplay.Weapon;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UnityIntegration;
using Mitfart.LeoECSLite.UnityIntegration.Name;

public class MainSystemsPack : EcsSystemsPack {
   protected override void RegisterSystems() {
      Add<ConvertSceneSys>();

      AddPack<LevelSystems>();
      AddPack<GetUnityDataSystems>();

      AddPack<PlayerSystems>();
      AddPack<MovementSystems>();
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