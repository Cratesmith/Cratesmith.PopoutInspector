using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR

#endif

#if UNITY_EDITOR
namespace Cratesmith.PopoutInspector
{
    [CustomPropertyDrawer(typeof(UnityEngine.Object), true)]
    public class ObjectDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.objectReferenceValue != null && !property.hasMultipleDifferentValues)
            {
                var wasEnabled = GUI.enabled;
                GUI.enabled = true;
                var indentedPos = EditorGUI.IndentedRect(position);
                var buttonRect = new Rect(indentedPos.x - indentedPos.height, indentedPos.y, indentedPos.height, indentedPos.height);
                if (GUI.Button(buttonRect, "", "OL Plus"))
                {
                    var windowRect = new Rect(GUIUtility.GUIToScreenPoint(position.position), new Vector2(400, 500));
                    PopupEditorWindow.Create(property.objectReferenceValue, windowRect);
                }
                GUI.enabled = wasEnabled;
            }
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
#endif