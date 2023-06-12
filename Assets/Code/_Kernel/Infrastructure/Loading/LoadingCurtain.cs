using System.Collections;
using UnityEngine;

namespace Infrastructure.Loading {
  public class LoadingCurtain : MonoBehaviour, ILoadingCurtain {
    public CanvasGroup group;
    public float       fadeDuration;

    private float _startTime;



    private void Awake() => DontDestroyOnLoad(this);

    public void Show() => StartCoroutine(ShowRoutine());
    public void Hide() => StartCoroutine(HideRoutine());

    public void Progress(float progress) { }



    private IEnumerator ShowRoutine() {
      gameObject.SetActive(true);
      group.alpha = 0f;

      _startTime = Time.time;
      var passedTime = 0f;

      while (passedTime < fadeDuration) {
        group.alpha = passedTime / fadeDuration;
        yield return null;

        passedTime = Time.time - _startTime;
      }
    }

    private IEnumerator HideRoutine() {
      group.alpha = 1f;
      
      _startTime  = Time.time;
      var passedTime = 0f;

      while (passedTime < fadeDuration) {
        group.alpha = 1f - passedTime / fadeDuration;
        yield return null;

        passedTime = Time.time - _startTime;
      }

      gameObject.SetActive(false);
    }
  }
}