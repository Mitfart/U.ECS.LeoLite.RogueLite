using UnityEditor;
using UnityEngine;

namespace AudioGroup.Editor {
  [CanEditMultipleObjects]
  [CustomEditor(typeof(AudioGroup), true)]
  public class AudioGroupEditor : UnityEditor.Editor {
    private const string PLAY_PREVIEW = "Preview";
    private const float  GAP          = 20f;

    private static AudioSource _TestAudioSource;



    public override void OnInspectorGUI() {
      if (target is not AudioGroup audioEvent)
        return;

      DrawDefaultInspector();

      GUILayout.Space(GAP);

      if (GUILayout.Button(PLAY_PREVIEW))
        audioEvent.Play(TestAudioSource());
    }



    private static AudioSource TestAudioSource() => _TestAudioSource ??= CreateTestAudioSource();

    private static AudioSource CreateTestAudioSource() {
      return new GameObject { hideFlags = HideFlags.HideInHierarchy }
       .AddComponent<AudioSource>();
    }
  }
}