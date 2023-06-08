using UnityEditor;
using UnityEngine;

namespace Debug.Gizmos.Editor {
  [CustomEditor(typeof(GizmosService))]
  public class GizmosServiceEditor : UnityEditor.Editor {
    public override void OnInspectorGUI() {
      DrawDefaultInspector();

      if (target is not GizmosService script)
        return;

      bool enabled = Application.isPlaying;

      GUI.enabled = enabled;
      GUILayout.BeginHorizontal();
      GUI.enabled = enabled && !script.IsActive;
      if (GUILayout.Button("On"))
        script.On();
      GUI.enabled = enabled && script.IsActive;
      if (GUILayout.Button("Off"))
        script.Off();
      GUILayout.EndHorizontal();
      GUI.enabled = enabled;
      
      if (GUILayout.Button("Toggle"))
        script.Toggle();
    }
  }
}