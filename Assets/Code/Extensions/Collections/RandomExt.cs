using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extensions.Collections {
   public static class RandomExt {
      public static T Random<T>(this IReadOnlyList<T> source, params T[] exclude) {
         List<T> collection = source as List<T> ?? source.ToList();
         collection.RemoveAll(exclude.Contains);

         if (collection.Count == 0)
            throw new Exception(message: "Excluded all items");

         return collection[collection.RandomIndex()];
      }


      private static int RandomIndex<T>(this IReadOnlyCollection<T> source)
         => Mathf.RoundToInt(
            UnityEngine.Random.Range(
               minInclusive: 0,
               source.Count - 1
            )
         );
   }
}