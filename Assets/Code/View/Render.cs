using UnityEngine;

namespace Views {
  public class Render : MonoBehaviour, IRender {
    [field: SerializeField] public Camera Camera { get; private set; }
  }
}