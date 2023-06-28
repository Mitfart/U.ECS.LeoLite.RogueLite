using UnityEngine;

namespace Level {
   public class Door : MonoBehaviour {
      public Location NextLocation { get; private set; }
      public Room     NextRoom     { get; private set; }

      public void Construct(Location location, Room room) {
         NextLocation = location;
         NextRoom     = room;
      }
   }
}