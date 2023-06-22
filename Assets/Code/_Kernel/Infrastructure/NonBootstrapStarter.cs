using UnityEngine;

namespace Infrastructure {
  [DefaultExecutionOrder(-10)]
  public class NonBootstrapStarter : MonoBehaviour {
#if UNITY_EDITOR
    private void Awake() {
      if (FindObjectOfType<Bootstrap>() == null)
        Instantiate(Resources.Load<Bootstrap>(AssetPath.BOOTSTRAP));
    }
#endif
  }
}