using UnityEditor;
using UnityEngine;

namespace Structs.Weighted.Editor {
  [CustomPropertyDrawer(typeof(Weighted<>))]
  public class WeightedDrawer : PropertyDrawer {
    private const string VALUE  = "value";
    private const string WEIGHT = "weight";
    private const int    WIDTH  = 24 * 2;


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
      SerializedProperty lootProp   = property.FindPropertyRelative(VALUE);
      SerializedProperty weightProp = property.FindPropertyRelative(WEIGHT);

      position.width -= WIDTH;
      EditorGUI.PropertyField(position, lootProp, label, true);

      position.x      += position.width + WIDTH;
      position.width  =  WIDTH;
      position.height =  EditorGUI.GetPropertyHeight(lootProp);
      position.x      -= position.width;
      EditorGUI.PropertyField(position, weightProp, GUIContent.none);
    }
  }
}