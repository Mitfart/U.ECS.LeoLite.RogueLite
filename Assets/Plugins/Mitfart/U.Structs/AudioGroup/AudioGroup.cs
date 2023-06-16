using System.Linq;
using UnityEngine;

namespace AudioGroup {
  public abstract class AudioGroup : ScriptableObject, IAudioGroup {
    [field: SerializeField] public AudioClip[] Clips { get; protected set; }


    protected virtual void OnValidate() {
      Clips = Clips.Where(clip => clip != default).ToArray();
    }

    protected bool HasClips() => Clips is { Length: > 0 };

    public abstract void Play(AudioSource source, Vector3 position = default);
  }
}