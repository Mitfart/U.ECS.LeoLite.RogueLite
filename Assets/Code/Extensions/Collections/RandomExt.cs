using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extensions.Collections {
   public static class RandomExt {
      public static T Random<T>(this IReadOnlyList<T> collection, params T[] exclude) {
         T result;

         do {
            result = collection[collection.RandomIndex()];
         } while (exclude.Contains(result));

         return result;
      }

      private static int RandomIndex<T>(this IReadOnlyCollection<T> collection, params int[] exclude) {
         int randomI;

         do {
            randomI = Mathf.RoundToInt(UnityEngine.Random.Range(minInclusive: 0, collection.Count - 1));
         } while (exclude.Contains(randomI));

         return randomI;
      }
   }
}