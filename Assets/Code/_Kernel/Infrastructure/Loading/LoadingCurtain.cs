using System.Collections;
using Unity.VisualScripting;
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
         group.alpha = 0;

         _startTime = Time.time;
         var passedTime = 0f;

         while (passedTime < fadeDuration) {
            group.alpha = passedTime / fadeDuration;
            passedTime  = Time.time - _startTime;
            yield return null;
         }
      }

      private IEnumerator HideRoutine() {
         group.alpha = 1;

         _startTime = Time.time;
         var passedTime = 0f;

         while (passedTime < fadeDuration) {
            group.alpha = 1f        - passedTime / fadeDuration;
            passedTime  = Time.time - _startTime;
            yield return null;
         }
      }
   }
}