using Extensions.Collections;
using Gameplay.Level;
using Gameplay.Level.StaticData;

namespace Infrastructure.StateMachine.States {
   public class SetupGameState : GameState {
      private readonly Location _location;

      public SetupGameState(Location location) {
         _location = location;
      }

      public override void Enter() {
         StateMachine.Enter<LoadLevelState, NextLevel>(
            new NextLevel(
               _location,
               _location.DefaultRooms.Random()
            )
         );
      }
   }
}