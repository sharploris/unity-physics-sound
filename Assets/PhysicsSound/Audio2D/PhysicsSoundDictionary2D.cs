using UnityEngine;

namespace PhysicsSound.Audio2D
{
    [CreateAssetMenu(fileName = "2D Physics Sound Dictionary", menuName = "Physics Sounds/2D Physics Sound Dictionary", order = 4)]
    public class PhysicsSoundDictionary2D : ScriptableObject
    {
        [SerializeField] private AudioClip[] _defaultClips = new AudioClip[0];
        [SerializeField] private PhysicsSound2D[] _physicsSounds = new PhysicsSound2D[0];

        public AudioClip[] GetClipsFromMaterial(PhysicsMaterial2D material)
        {
            if (material == null)
            {
                return _defaultClips;
            }

            AudioClip[] foundClips = null;
            for (var i = 0; i < _physicsSounds.Length; i++)
            {
                if(material.name != _physicsSounds[i].MaterialKey) { continue; }

                foundClips = _physicsSounds[i].AudioClips;
                break;
            }

            return foundClips ?? _defaultClips;
        }
    }
}
