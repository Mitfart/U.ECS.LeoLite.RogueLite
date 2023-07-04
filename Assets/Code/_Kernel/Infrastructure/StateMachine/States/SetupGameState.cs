using Extensions.Collections;
using Gameplay.Environment;
using Gameplay.Environment.StaticData;
using Infrastructure.AssetsManagement;

namespace Infrastructure.StateMachine.States {
   public class SetupGameState : GameState {
      public Location StartLocation { get; }


      public SetupGameState(
         IGameStateMachine stateMachine,
         IAssets           assets
      ) : base(stateMachine) {
         StartLocation = assets.Load<Location>(AssetPath.START_LOCATION);
      }

      public override void Enter() {
         StateMachine.Enter<LoadLevelState, NextLevel>(
            new NextLevel(
               StartLocation,
               StartLocation.DefaultRooms.Random()
            )
         );
      }
   }
}