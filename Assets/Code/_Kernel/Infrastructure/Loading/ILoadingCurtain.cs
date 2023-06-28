namespace Infrastructure.Loading {
   public interface ILoadingCurtain {
      void Show();
      void Progress(float progress);
      void Hide();
   }
}