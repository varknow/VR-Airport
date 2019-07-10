using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class ParticleEffect
    {
        public ParticleSystem particle;
        public string name;
        public Transform defaultPlayPos;
    }
}