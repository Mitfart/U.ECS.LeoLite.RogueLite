using Extensions.Collections;
using Level;

namespace Infrastructure.StateMachine.States {
   public class SetupGameState : GameState {
      private readonly Location _location;
      private readonly Stage    _stage;

      public SetupGameState(Location location, Stage stage) {
         _location = location;
         _stage    = stage;
      }

      public override void Enter() {
         Room room = _location.DefaultRooms.Random();

         _stage.SetLocation(_location);

         StateMachine.Enter<LoadRoomState, Room>(room);
      }
   }
}