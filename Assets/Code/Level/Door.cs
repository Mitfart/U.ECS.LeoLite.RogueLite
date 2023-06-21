namespace Level {
  public class Door {
    public Location NextLocation { get; }
    public Room     NextRoom     { get; }

    public Door(Location location, Room room) {
      NextLocation = location;
      NextRoom     = room;
    }
  }
}