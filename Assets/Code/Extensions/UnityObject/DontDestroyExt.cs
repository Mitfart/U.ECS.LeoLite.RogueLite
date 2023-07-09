namespace Extensions.UnityObject {
   public static class DontDestroyExt {
      public static TObj DontDestroy<TObj>(this TObj obj) where TObj : UnityEngine.Object {
         UnityEngine.Object.DontDestroyOnLoad(obj);
         return obj;
      }
   }
}