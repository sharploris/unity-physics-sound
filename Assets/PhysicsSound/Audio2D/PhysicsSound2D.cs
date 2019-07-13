using System;
using UnityEngine;
using PhysicsSound.Shared;

namespace PhysicsSound.Audio2D
{
    [Serializable]
    public class PhysicsSound2D : AudioClipArray
    {
        [SerializeField] private PhysicsMaterial2D _materialKey = null;

        public string MaterialKey => _materialKey ? _materialKey.name : null;
    }
}
