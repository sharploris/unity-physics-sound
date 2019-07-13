using UnityEditor;
using UnityEngine;

namespace PhysicsSound.Shared.Editor
{
    public abstract class PhysicsSoundEditor : UnityEditor.Editor
    {
        protected string Name;
        protected SerializedProperty Material;
        protected SerializedProperty AudioClips;

        protected virtual void OnEnable()
        {
            Material = serializedObject.FindProperty("_materialKey");
            AudioClips = serializedObject.FindProperty("_audioClips");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            Name = serializedObject.FindProperty("m_Name").stringValue;

            EditorGUILayout.LabelField(Name, EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(Material);
            DrawClipArray(AudioClips);

            serializedObject.ApplyModifiedProperties();
        }

        protected void DrawClipArray(SerializedProperty clips)
        {
            EditorGUILayout.PropertyField(clips);
            if (!clips.isExpanded) { return; }

            EditorGUI.indentLevel += 1;
            clips.arraySize = EditorGUILayout.IntField("Total Clips", clips.arraySize);
            for (var i = 0; i < clips.arraySize; i++)
            {
                EditorGUILayout.PropertyField(clips.GetArrayElementAtIndex(i),
                    new GUIContent($"Clip {i + 1}"));
            }
            EditorGUI.indentLevel -= 1;
        }
    }
}
