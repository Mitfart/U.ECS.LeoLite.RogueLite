using System.Collections.Generic;
using Level;
using Views;

namespace Infrastructure.StateMachine.States {
  public class BootstrapState : GameState {
    private readonly IReadOnlyList<Location> _locations;



    public BootstrapState(IReadOnlyList<Location> locations, IRender _) { // hack: Instantiating IRender throw Scope
      _locations = locations;
    }

    public override void Enter() {
      Location firstLocation = _locations[0];
      string   firstRoom     = firstLocation.DefaultRooms[0];

      StateMachine.Enter<LoadRoomState, string>(firstRoom);
    }
  }
}