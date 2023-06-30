using UnityEngine;

namespace Level {
   public class Door : MonoBehaviour {
      public Location NextLocation { get; private set; }
      public Room     NextRoom     { get; private set; }



      public Door Construct(
         Location nextLocation,
         Room     nextRoom
      ) {
         NextLocation = nextLocation;
         NextRoom     = nextRoom;
         return this;
      }
   }
}