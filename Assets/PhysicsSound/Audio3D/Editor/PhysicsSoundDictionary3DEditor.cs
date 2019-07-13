using UnityEditor;
using PhysicsSound.Shared.Editor;

namespace PhysicsSound.Audio3D.Editor
{
    [CustomEditor(typeof(PhysicsSoundDictionary3D))]
    public class PhysicsSoundDictionary3DEditor : PhysicsSoundDictionaryEditor {
        protected override string BuildName(string objectName)
        {
            if (string.IsNullOrEmpty(objectName))
            {
                objectName = "Untitled";
            }

            return $"3D Physics Sound Dictionary - {objectName}";
        }
    }
}
