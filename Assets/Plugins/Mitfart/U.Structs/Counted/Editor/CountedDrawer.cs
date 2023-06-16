using UnityEditor;
using UnityEngine;

namespace Structs.Counted.Editor {
  [CustomPropertyDrawer(typeof(Counted<>), true)]
  public class CountedDrawer : PropertyDrawer {
    private const string VALUE = "value";
    private const string COUNT = "count";
    private const int    WIDTH = 24 * 2;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
      SerializedProperty lootProp  = property.FindPropertyRelative(VALUE);
      SerializedProperty countProp = property.FindPropertyRelative(COUNT);


      position.width -= WIDTH;
      EditorGUI.PropertyField(position, lootProp, label, true);

      position.x      += position.width + WIDTH;
      position.width  =  WIDTH;
      position.height =  EditorGUI.GetPropertyHeight(lootProp);
      position.x      -= position.width;
      EditorGUI.PropertyField(position, countProp, GUIContent.none);
    }
  }
}