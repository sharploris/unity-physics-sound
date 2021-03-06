﻿using UnityEditor;
using PhysicsSound.Shared.Editor;

namespace PhysicsSound.Audio3D.Editor
{
    [CustomEditor(typeof(PhysicsSound3D))]
    public class PhysicsSound3DEditor : PhysicsSoundEditor {
        protected override string BuildName(string objectName)
        {
            if (string.IsNullOrEmpty(objectName))
            {
                objectName = "Untitled";
            }

            return $"3D Physics Sounds - {objectName}";
        }
    }
}
