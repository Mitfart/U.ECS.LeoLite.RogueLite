using System.Collections.Generic;
using Level;

namespace Infrastructure.StateMachine.States {
   public class SetupGameState : GameState {
      private readonly IReadOnlyList<Location> _locations;



      public SetupGameState(IReadOnlyList<Location> locations) {
         _locations = locations;
      }



      public override void Enter() {
         Location firstLocation = _locations[0];
         string   firstRoom     = firstLocation.DefaultRooms[0];
         
         StateMachine.Enter<LoadRoomState, string>(firstRoom);
      }
   }
}