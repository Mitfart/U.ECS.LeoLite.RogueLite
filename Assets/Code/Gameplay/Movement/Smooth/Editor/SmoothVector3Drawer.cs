using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Movement.Smooth.Editor {
   [CustomPropertyDrawer(typeof(SmoothVector3))]
   public class SmoothVector3Drawer : PropertyDrawer {
      private const int   GAP       = 20;
      private const int   THICKNESS = 2;
      private const float DELTA     = .02f;
      private const float SCALE     = 50;
      private const float HEIGHT    = 5 * SCALE;



      public override void OnGUI(Rect origin, SerializedProperty property, GUIContent label) {
         EditorGUI.PropertyField(origin, property, label, includeChildren: true);

         if (!property.isExpanded) return;

         var     value = (SmoothVector3)property.GetUnderlyingValue();
         Vector2 pos   = origin.position + Vector2.up * (EditorGUI.GetPropertyHeight(property) + GAP);
         var     rect  = new Rect(pos, new Vector2(origin.width, HEIGHT));

         Vector3 moveStart  = Vector3.up * 2.5f;
         Vector3 moveFinish = Vector3.up * 1.5f;

         GUI.BeginClip(rect);
         Handles.color = Color.white.WithAlpha(alpha: .25f);
         Handles.DrawAAPolyLine(Texture2D.whiteTexture, THICKNESS, moveStart * SCALE, moveStart * SCALE + Vector3.right * rect.width);
         Handles.color = Color.yellow.WithAlpha(alpha: .25f);
         Handles.DrawAAPolyLine(Texture2D.whiteTexture, THICKNESS, moveFinish * SCALE, moveFinish * SCALE + Vector3.right * rect.width);
         Handles.color = Color.green;
         Handles.DrawAAPolyLine(Texture2D.whiteTexture, THICKNESS, GetPoints(value, moveStart, moveFinish, rect));
         GUI.EndClip();
      }


      public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => property.isExpanded ? EditorGUI.GetPropertyHeight(property) + HEIGHT : EditorGUI.GetPropertyHeight(property);


      private static Vector3[] GetPoints(SmoothVector3 value, Vector3 moveStart, Vector3 moveFinish, Rect rect) {
         var smoothClone = new SmoothVector3 {
            Freaquency     = value.Freaquency,    //
            Damping        = value.Damping,       //
            Responsiveness = value.Responsiveness //
         };

         int count  = Mathf.CeilToInt(rect.width / SCALE / DELTA);
         var result = new Vector3[count];


         smoothClone.Init(moveStart);

         for (var i = 0; i < count; i++) {
            result[i] = (smoothClone.Update(DELTA, moveFinish) + Vector3.right * (DELTA * i)) * SCALE;
         }

         return result;
      }
   }
}