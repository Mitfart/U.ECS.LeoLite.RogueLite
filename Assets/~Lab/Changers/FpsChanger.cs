using UnityEngine;

namespace DebugTools.Changers {
  public class FpsChanger : BaseChanger {
    [SerializeField][Range(2, 500)] private int targetFps = 60;

    public override void Change()    => Application.targetFrameRate = targetFps;
    public override void Normalize() => Application.targetFrameRate = -1;
  }
}