using UnityEngine;

namespace Infrastructure.Loading {
  public class LoadingCurtain : MonoBehaviour, ILoadingCurtain {
    private void Awake() => DontDestroyOnLoad(this);

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public void Progress(float progress) { }
  }
}