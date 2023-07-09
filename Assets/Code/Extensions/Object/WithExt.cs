using System;

namespace Extensions.Object {
   public static class WithExt {
      public static T With<T>(this T t, Action<T> action, Func<T, bool> @if = null) {
         if (@if?.Invoke(t) == true)
            action?.Invoke(t);
         
         return t;
      } 
   }
}