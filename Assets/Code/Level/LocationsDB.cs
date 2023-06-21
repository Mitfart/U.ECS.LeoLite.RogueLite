using System.Collections.Generic;
using UnityEngine;

namespace Level {
  [CreateAssetMenu]
  public class LocationsDB : ScriptableObject {
    [SerializeField] private List<Location> locations;

    public IReadOnlyCollection<Location> Locations => locations;
  }
}