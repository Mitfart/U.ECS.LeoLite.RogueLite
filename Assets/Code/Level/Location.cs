using UnityEngine;

namespace Level {
  [CreateAssetMenu]
  public partial class Location : ScriptableObject {
    public string Title;
    public Color  Color;

    [SerializeField, HideInInspector] private string[] defaultRoomsNames;
    [SerializeField, HideInInspector] private string[] secretRoomsNames;
    [SerializeField, HideInInspector] private string[] shopRoomsNames;

    public string[] DefaultRooms => defaultRoomsNames;
    public string[] SecretRooms  => secretRoomsNames;
    public string[] ShopRooms    => shopRoomsNames;

    // public Items[] Items;
  }
}