using UnityEditor;
using UnityEngine;

namespace Structs.Optional.Editor {
  [CustomPropertyDrawer(typeof(Optional<>), true)]
  public class OptionalDrawer : PropertyDrawer {
    private const string VALUE   = "value";
    private const string ENABLED = "enabled";
    private const int    WIDTH   = 24;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
      SerializedProperty valueProp   = property.FindPropertyRelative(VALUE);
      SerializedProperty enabledProp = property.FindPropertyRelative(ENABLED);

      position.width -= WIDTH;
      EditorGUI.BeginDisabledGroup(!enabledProp.boolValue);
      EditorGUI.PropertyField(position, valueProp, label, true);
      EditorGUI.EndDisabledGroup();

      position.x     += position.width + WIDTH;
      position.width =  position.height = EditorGUI.GetPropertyHeight(valueProp);
      position.x     -= position.width;
      EditorGUI.PropertyField(position, enabledProp, GUIContent.none);
    }
  }
}