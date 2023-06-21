using UnityEngine;

namespace Level {
  public class SpawnPoint : MonoBehaviour {
    public Vector3 Position { get; private set; }

    private void Awake() {
      Position = transform.position;
    }
  }
}