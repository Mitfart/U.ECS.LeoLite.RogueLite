using UnityEditor;
using UnityEngine;

namespace Structs.Optional.Editor {
   [CustomPropertyDrawer(typeof(Optional<>), true)]
   public class OptionalDrawer : PropertyDrawer {
      private const string _VALUE   = "value";
      private const string _ENABLED = "enabled";
      private const int    _WIDTH   = 18;
      private const int    _GAP     = 5;

      public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
         EditorGUI.BeginProperty(position, label, property);
         SerializedProperty valueProp   = property.FindPropertyRelative(_VALUE);
         SerializedProperty enabledProp = property.FindPropertyRelative(_ENABLED);

         position.width -= _WIDTH + _GAP;
         EditorGUI.BeginDisabledGroup(!enabledProp.boolValue);
         EditorGUI.PropertyField(position, valueProp, label, true);
         EditorGUI.EndDisabledGroup();

         position.x     += position.width + _WIDTH + _GAP;
         position.width =  position.height = _WIDTH;
         position.x     -= position.width;
         EditorGUI.PropertyField(position, enabledProp, GUIContent.none);
         EditorGUI.EndProperty();
      }

      public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
         SerializedProperty valueProp = property.FindPropertyRelative(_VALUE);
         return EditorGUI.GetPropertyHeight(valueProp);
      }
   }
}