using System;
using UnityEngine;
using PhysicsSound.Shared;

namespace PhysicsSound.Audio3D
{
    [Serializable]
    [CreateAssetMenu(fileName = "3D Physics Sounds", menuName = "Physics Sounds/3D Physics Sounds", order = 2)]
    public class PhysicsSound3D : AudioClipArray
    {
        [SerializeField] private PhysicMaterial _materialKey = null;

        public string MaterialKey => _materialKey ? _materialKey.name : null;
    }
}
