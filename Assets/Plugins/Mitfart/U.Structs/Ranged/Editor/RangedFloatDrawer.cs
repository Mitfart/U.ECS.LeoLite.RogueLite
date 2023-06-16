using System;
using UnityEditor;
using UnityEngine;

namespace Structs.Ranged.Editor {
  [CustomPropertyDrawer(typeof(RangeEdges))]
  [CustomPropertyDrawer(typeof(Ranged), true)]
  public class RangedFloatDrawer : PropertyDrawer {
    private const float  WIDTH    = 45;
    private const float  MARGIN   = 5;
    private const string MIN      = "min";
    private const string MAX      = "max";
    private const string ROUNDED  = "rounded";
    private const string MIN_EDGE = "minEdge";
    private const string MAX_EDGE = "maxEdge";


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
      label    = EditorGUI.BeginProperty(position, label, property);
      position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

      int indent = EditorGUI.indentLevel;
      EditorGUI.indentLevel = 0;

      SerializedProperty minProp     = property.FindPropertyRelative(MIN);
      SerializedProperty maxProp     = property.FindPropertyRelative(MAX);
      SerializedProperty roundedProp = property.FindPropertyRelative(ROUNDED);
      SerializedProperty minEdgeProp = property.FindPropertyRelative(MIN_EDGE);
      SerializedProperty maxEdgeProp = property.FindPropertyRelative(MAX_EDGE);

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
      Rect roundRect = new(position.x, position.y, position.height, position.height);
      position.x += position.height + MARGIN;
      return roundRect;
    }

    private static Rect FloatRect(ref Rect position) {
      Rect rect = new(position.x, position.y, WIDTH, position.height);
      position.x += WIDTH + MARGIN;
      return rect;
    }

    private static Rect SliderRect(ref Rect position) {
      float width = position.width - (WIDTH + MARGIN) * 2f - position.height;
      Rect  rect  = new(position.x, position.y, width, position.height);
      position.x += width + MARGIN;
      return rect;
    }
  }
}