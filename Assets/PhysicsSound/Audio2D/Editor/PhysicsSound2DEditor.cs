using UnityEditor;
using PhysicsSound.Shared.Editor;

namespace PhysicsSound.Audio2D.Editor
{
    [CustomEditor(typeof(PhysicsSound2D))]
    public class PhysicsSound2DEditor : PhysicsSoundEditor {
        protected override string BuildName(string objectName)
        {
            if (string.IsNullOrEmpty(objectName))
            {
                objectName = "Untitled";
            }

            return $"2D Physics Sounds - {objectName}";
        }
    }
}
