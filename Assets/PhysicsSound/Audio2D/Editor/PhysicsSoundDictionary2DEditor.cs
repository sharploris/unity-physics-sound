using UnityEditor;
using PhysicsSound.Shared.Editor;

namespace PhysicsSound.Audio2D.Editor
{
    [CustomEditor(typeof(PhysicsSoundDictionary2D))]
    public class PhysicsSoundDictionary2DEditor : PhysicsSoundDictionaryEditor {
        protected override string BuildName(string objectName)
        {
            if (string.IsNullOrEmpty(objectName))
            {
                objectName = "Untitled";
            }

            return $"2D Physics Sound Dictionary - {objectName}";
        }
    }
}
