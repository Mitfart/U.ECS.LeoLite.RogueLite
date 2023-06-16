using Structs.Ranged;
using UnityEngine;

namespace AudioGroup {
  [CreateAssetMenu(menuName = "AudioGroup/New RandomAudioGroup")]
  public class RandomAudioGroup : AudioGroup {
    [RangeEdges(0f, 1f)] public Ranged volume;
    [RangeEdges(0f, 2f)] public Ranged pitch;

    public bool allowRepeat;

    private int _lastClipIndex;


    
    public override void Play(AudioSource source, Vector3 position = default) {
      if (!HasClips())
        return;

      source.clip   = RandomClip();
      source.volume = Random.Range(volume.Min, volume.Max);
      source.pitch  = Random.Range(pitch.Min,  pitch.Max);

      source.transform.position = position;

      source.Play();
    }


    private AudioClip RandomClip() {
      return Clips[
        allowRepeat
          ? RandomIndex()
          : UnrepeatableIndex()
      ];
    }

    private int UnrepeatableIndex() {
      int clipIndex = RandomIndex();

      clipIndex      %= _lastClipIndex;
      _lastClipIndex =  clipIndex;

      return clipIndex;
    }

    private int RandomIndex() => Random.Range(0, Clips.Length - 1);
  }
}