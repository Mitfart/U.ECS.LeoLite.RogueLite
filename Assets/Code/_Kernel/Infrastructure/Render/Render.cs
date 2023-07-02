using UnityEngine;

namespace Infrastructure.Render {
   public class Render : MonoBehaviour, IRender {
      [field: SerializeField] public Camera Camera { get; private set; }
   }
}