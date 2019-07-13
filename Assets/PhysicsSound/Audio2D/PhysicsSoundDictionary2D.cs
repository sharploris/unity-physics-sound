using UnityEngine;

namespace PhysicsSound.Audio2D
{
    [CreateAssetMenu(fileName = "2D Physics Sound Dictionary", menuName = "Physics Sounds/2D Physics Sound Dictionary", order = 4)]
    public class PhysicsSoundDictionary2D : ScriptableObject
    {
        [SerializeField] private AudioClip[] _defaultClips = new AudioClip[0];
        [SerializeField] private PhysicsSound2D[] _physicsSounds = new PhysicsSound2D[0];

        private AudioClip[] _currentClips;

        /// <summary>
        /// The current active array of audio clips as set by update active audio clips method.
        /// </summary>
        public AudioClip[] ActiveAudioClips => _currentClips ?? _defaultClips;

        /// <summary>
        /// This method allows you to update the cached array of active audio clips within this object. It can be accessed from the ActiveAudioClips property.
        /// </summary>
        /// <param name="material">The physics material that has been interacted with.</param>
        public void UpdateActiveAudioClips(PhysicsMaterial2D material)
        {
            _currentClips = FindAudioClipsFromMaterial(material);
        }

        /// <summary>
        /// This method allows you to get an array of audio clips that correspond to a physics material.
        /// </summary>
        /// <param name="material">The physics material that has been interacted with.</param>
        /// <returns>A corresponding array of possible audio clips.</returns>
        public AudioClip[] GetClipsFromMaterial(PhysicsMaterial2D material) => FindAudioClipsFromMaterial(material);

        private AudioClip[] FindAudioClipsFromMaterial(PhysicsMaterial2D material)
        {
            if (material == null)
            {
                return _defaultClips;
            }

            AudioClip[] foundClips = null;
            for (var i = 0; i < _physicsSounds.Length; i++)
            {
                if (material.name != _physicsSounds[i].MaterialKey) { continue; }

                foundClips = _physicsSounds[i].AudioClips;
                break;
            }

            return foundClips ?? _defaultClips;
        }
    }
}
