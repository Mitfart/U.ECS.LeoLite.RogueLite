using UnityEditor;
using UnityEngine;

namespace DebugTools.Changers.Editor {
  [CustomEditor(typeof(BaseChanger), true)]
  public class MonoChangerEditor : UnityEditor.Editor {
    public override void OnInspectorGUI() {
      DrawDefaultInspector();

      if (target is not BaseChanger script)
        return;

      GUILayout.Space(25f);
      GUILayout.BeginHorizontal();
      if (GUILayout.Button("Change"))
        script.Change();
      if (GUILayout.Button("Normalize"))
        script.Normalize();
      GUILayout.EndHorizontal();
    }
  }
}