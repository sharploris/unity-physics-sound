using UnityEngine;

namespace PhysicsSound.Audio3D
{
    [CreateAssetMenu(fileName = "Physics Sounds 3D", menuName = "Physics Sounds/3D Physics Sound Dictionary", order = 1)]
    public class PhysicsSoundDictionary3D : ScriptableObject
    {
        [SerializeField] private AudioClip[] _defaultClips = new AudioClip[0];
        [SerializeField] private PhysicsSound3D[] _physicsSounds = new PhysicsSound3D[0];

        public AudioClip[] GetClipsFromMaterial(PhysicMaterial material)
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
