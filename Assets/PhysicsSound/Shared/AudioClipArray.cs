using System;
using UnityEngine;

namespace PhysicsSound.Shared
{
    [Serializable]
    public class AudioClipArray : ScriptableObject
    {
        [SerializeField]
        private AudioClip[] _audioClips = new AudioClip[0];

        public AudioClip[] AudioClips => _audioClips;
    }
}
