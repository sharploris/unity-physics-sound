using System;
using UnityEngine;

namespace PhysicsSound.Shared
{
    [Serializable]
    public class AudioClipArray
    {
        [SerializeField]
        private AudioClip[] _audioClips = new AudioClip[0];

        public AudioClip[] AudioClips => _audioClips;
    }
}
