using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Gameplay.Movement.Smooth.Editor {
   [CustomPropertyDrawer(typeof(SmoothVector3))]
   public class SmoothVector3Drawer : PropertyDrawer {
      private const int   _GAP       = 20;
      private const int   _THICKNESS = 2;
      private const float _DELTA     = .02f;
      private const float _SCALE     = 50;
      private const float _HEIGHT    = 5 * _SCALE;



      public override void OnGUI(Rect origin, SerializedProperty property, GUIContent label) {
         EditorGUI.PropertyField(origin, property, label, includeChildren: true);

         if (!property.isExpanded)
            return;

         var     value = (SmoothVector3)property.GetUnderlyingValue();
         Vector2 pos   = origin.position + Vector2.up * (EditorGUI.GetPropertyHeight(property) + _GAP);
         var     rect  = new Rect(pos, new Vector2(origin.width, _HEIGHT));

         Vector3 moveStart  = Vector3.up * 2.5f;
         Vector3 moveFinish = Vector3.up * 1.5f;

         GUI.BeginClip(rect);
         Handles.color = Color.white.WithAlpha(alpha: .25f);
         Handles.DrawAAPolyLine(Texture2D.whiteTexture, _THICKNESS, moveStart * _SCALE, moveStart * _SCALE + Vector3.right * rect.width);

         Handles.color = Color.yellow.WithAlpha(alpha: .25f);
         Handles.DrawAAPolyLine(Texture2D.whiteTexture, _THICKNESS, moveFinish * _SCALE, moveFinish * _SCALE + Vector3.right * rect.width);

         Handles.color = Color.green;
         Handles.DrawAAPolyLine(Texture2D.whiteTexture, _THICKNESS, GetPoints(value, moveStart, moveFinish, rect));
         GUI.EndClip();
      }


      public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => property.isExpanded ? EditorGUI.GetPropertyHeight(property) + _HEIGHT : EditorGUI.GetPropertyHeight(property);


      private static Vector3[] GetPoints(SmoothVector3 value, Vector3 moveStart, Vector3 moveFinish, Rect rect) {
         var smoothClone = new SmoothVector3 {
            Freaquency     = value.Freaquency,    //
            Damping        = value.Damping,       //
            Responsiveness = value.Responsiveness //
         };

         int count  = Mathf.CeilToInt(rect.width / _SCALE / _DELTA);
         var result = new Vector3[count];


         smoothClone.Init(moveStart);

         for (var i = 0; i < count; i++) {
            result[i] = (smoothClone.Update(_DELTA, moveFinish) + Vector3.right * (_DELTA * i)) * _SCALE;
         }

         return result;
      }
   }
}