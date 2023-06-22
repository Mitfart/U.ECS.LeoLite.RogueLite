using System.Collections.Generic;
using UnityEngine;

namespace Level {
  [CreateAssetMenu]
  public partial class Location : ScriptableObject {
    public string Title;
    public Color  Color;

    [SerializeField, HideInInspector] private string[] defaultRoomsNames;
    [SerializeField, HideInInspector] private string[] secretRoomsNames;
    [SerializeField, HideInInspector] private string[] shopRoomsNames;

    public IReadOnlyList<string> DefaultRooms => defaultRoomsNames;
    public IReadOnlyList<string> SecretRooms  => secretRoomsNames;
    public IReadOnlyList<string> ShopRooms    => shopRoomsNames;

    // public Items[] Items;
  }
}