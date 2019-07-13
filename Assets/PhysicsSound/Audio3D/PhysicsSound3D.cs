using System;
using UnityEngine;
using PhysicsSound.Shared;

namespace PhysicsSound.Audio3D
{
    [Serializable]
    public class PhysicsSound3D : AudioClipArray
    {
        [SerializeField] private PhysicMaterial _materialKey = null;

        public string MaterialKey => _materialKey ? _materialKey.name : null;
    }
}
