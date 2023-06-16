using UnityEngine;

namespace AudioGroup {
  public interface IAudioGroup {
    AudioClip[] Clips { get; }
    
    void Play(AudioSource source, Vector3 position = default);
  }
}