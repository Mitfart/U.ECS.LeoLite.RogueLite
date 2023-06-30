using System.Collections.Generic;
using Level;

namespace Infrastructure.StateMachine.States {
   public class SetupGameState : GameState {
      private readonly IReadOnlyList<Location> _locations;
      private readonly Stage                   _stage;

      public SetupGameState(IReadOnlyList<Location> locations, Stage stage) {
         _locations = locations;
         _stage     = stage;
      }

      public override void Enter() {
         Location location = _locations[0];
         Room     room     = location.DefaultRooms[0];

         _stage.SetLocation(location);

         StateMachine.Enter<LoadRoomState, Room>(room);
      }
   }
}