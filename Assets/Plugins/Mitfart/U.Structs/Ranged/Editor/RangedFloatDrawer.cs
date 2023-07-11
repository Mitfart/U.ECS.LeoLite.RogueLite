using System;
using UnityEditor;
using UnityEngine;

namespace Structs.Ranged.Editor {
   [CustomPropertyDrawer(typeof(RangeEdges))]
   [CustomPropertyDrawer(typeof(Ranged), true)]
   public class RangedFloatDrawer : PropertyDrawer {
      private const string _MIN         = "min";
      private const string _MAX         = "max";
      private const string _ROUNDED     = "rounded";
      private const string _MIN_EDGE    = "minEdge";
      private const string _MAX_EDGE    = "maxEdge";
      private const float  _HEIGHT      = 18;
      private const float  _FLOAT_WIDTH = 45;
      private const float  _GAP         = 5;


      public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
         label    = EditorGUI.BeginProperty(position, label, property);
         position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

         int indent = EditorGUI.indentLevel;
         EditorGUI.indentLevel = 0;

         SerializedProperty minProp     = property.FindPropertyRelative(_MIN);
         SerializedProperty maxProp     = property.FindPropertyRelative(_MAX);
         SerializedProperty roundedProp = property.FindPropertyRelative(_ROUNDED);
         SerializedProperty minEdgeProp = property.FindPropertyRelative(_MIN_EDGE);
         SerializedProperty maxEdgeProp = property.FindPropertyRelative(_MAX_EDGE);

         float      min        = minProp.floatValue;
         float      max        = maxProp.floatValue;
         bool       round      = roundedProp.boolValue;
         float      minEdge    = minEdgeProp.floatValue;
         float      maxEdge    = maxEdgeProp.floatValue;
         RangeEdges rangeEdges = attribute as RangeEdges ?? new RangeEdges(minEdge, maxEdge);

         Ranged ranged = Draw(
            position,
            new Ranged(
               min,
               max,
               rangeEdges.Min,
               rangeEdges.Max,
               round
            )
         );

         minProp.floatValue     = ranged.Min;
         maxProp.floatValue     = ranged.Max;
         roundedProp.boolValue  = ranged.Rounded;
         minEdgeProp.floatValue = ranged.MinEdge;
         maxEdgeProp.floatValue = ranged.MaxEdge;

         EditorGUI.indentLevel = indent;

         EditorGUI.EndProperty();
      }


      private static Ranged Draw(Rect position, Ranged ranged) {
         float min    = ranged.Min;
         float max    = ranged.Max;
         bool  round  = ranged.Rounded;
         float maxMin = ranged.MinEdge;
         float maxMax = ranged.MaxEdge;

         Rect minRect    = FloatRect(ref position);
         Rect sliderRect = SliderRect(ref position);
         Rect maxRect    = FloatRect(ref position);
         Rect roundRect  = RoundRect(ref position);

         min   = EditorGUI.FloatField(minRect, min);
         max   = EditorGUI.FloatField(maxRect, max);
         round = EditorGUI.Toggle(roundRect, round);

         if (round && Math.Abs(maxMax - maxMin) > 1f) {
            min    = Mathf.Round(min);
            max    = Mathf.Round(max);
            maxMin = Mathf.Round(maxMin);
            maxMax = Mathf.Round(maxMax);
         }

         if (Math.Abs(maxMax - maxMin) < .00001f) {
            maxMax++;
            Debug.LogWarning("Ranged MAX can't be equal to MIN!");
         }

         EditorGUI.MinMaxSlider(
            sliderRect,
            GUIContent.none,
            ref min,
            ref max,
            maxMin,
            maxMax
         );

         return new Ranged(
            min,
            max,
            maxMin,
            maxMax,
            round
         );
      }


      private static Rect RoundRect(ref Rect position) {
         Rect roundRect = new(position.x, position.y, _HEIGHT, _HEIGHT);
         position.x += _HEIGHT + _GAP;
         return roundRect;
      }

      private static Rect FloatRect(ref Rect position) {
         Rect rect = new(position.x, position.y, _FLOAT_WIDTH, _HEIGHT);
         position.x += _FLOAT_WIDTH + _GAP;
         return rect;
      }

      private static Rect SliderRect(ref Rect position) {
         float width = position.width - (_FLOAT_WIDTH + _GAP) * 2f - _HEIGHT;
         Rect  rect  = new(position.x, position.y, width, _HEIGHT);
         position.x += width + _GAP;
         return rect;
      }
   }
}