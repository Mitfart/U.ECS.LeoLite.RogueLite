using UnityEngine;

namespace DebugTools.Changers {
  public abstract class BaseChanger : MonoBehaviour {
    public abstract void Change();
    public abstract void Normalize();
  }
}