using UnityEditor;
using UnityEngine;

namespace PhysicsSound.Shared.Editor
{
    public abstract class PhysicsSoundDictionaryEditor : UnityEditor.Editor
    {
        protected string Name;
        protected SerializedProperty DefaultClips;
        protected SerializedProperty PhysicsSounds;

        protected virtual void OnEnable()
        {
            DefaultClips = serializedObject.FindProperty("_defaultClips");
            PhysicsSounds = serializedObject.FindProperty("_physicsSounds");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            Name = BuildName(serializedObject.FindProperty("m_Name").stringValue);

            EditorGUILayout.LabelField(Name, EditorStyles.boldLabel);
            DrawClipArray(DefaultClips);
            DrawPhysicsSoundArray(PhysicsSounds);

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

        protected void DrawPhysicsSoundArray(SerializedProperty physicsSounds)
        {
            EditorGUILayout.PropertyField(physicsSounds);
            if (!physicsSounds.isExpanded) { return; }

            EditorGUI.indentLevel += 1;
            physicsSounds.arraySize = EditorGUILayout.IntField("Total Clips", physicsSounds.arraySize);
            for (var i = 0; i < physicsSounds.arraySize; i++)
            {
                var physicsSound = physicsSounds.GetArrayElementAtIndex(i);
                var title = physicsSound.objectReferenceValue == null ? "<EMPTY>" : physicsSound.objectReferenceValue.name;
                
                EditorGUILayout.PropertyField(physicsSound,
                    new GUIContent(title));
            }
            EditorGUI.indentLevel -= 1;
        }

        protected abstract string BuildName(string objectName);
    }
}
