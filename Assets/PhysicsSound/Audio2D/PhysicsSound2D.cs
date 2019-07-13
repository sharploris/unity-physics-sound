using System;
using UnityEngine;
using PhysicsSound.Shared;

namespace PhysicsSound.Audio2D
{
    [Serializable]
    [CreateAssetMenu(fileName = "2D Physics Sounds", menuName = "Physics Sounds/2D Physics Sounds", order = 3)]
    public class PhysicsSound2D : AudioClipArray
    {
        [SerializeField] private PhysicsMaterial2D _materialKey = null;

        public string MaterialKey => _materialKey ? _materialKey.name : null;
    }
}
