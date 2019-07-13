using UnityEditor;
using UnityEngine;

namespace PhysicsSound.Audio3D.Editor
{
    [CustomEditor(typeof(PhysicsSound3D))]
    public class PhysicsSound3DEditor : UnityEditor.Editor
    {
        private string _name;
        private SerializedProperty _material;
        private SerializedProperty _audioClips;

        private void OnEnable()
        {
            _name = serializedObject.FindProperty("m_Name").stringValue;
            _material = serializedObject.FindProperty("_materialKey");
            _audioClips = serializedObject.FindProperty("_audioClips");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField(_name, EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_material);
            EditorGUILayout.PropertyField(_audioClips, true);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
