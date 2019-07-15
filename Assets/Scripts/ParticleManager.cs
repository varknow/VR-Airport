using System;
using UnityEngine;
namespace Assets.Scripts
{
    public class ParticleManager: MonoBehaviour
    {
        public ParticleEffect[] particles;

        private ParticleEffect searchForEffect(string name)
        {
            return Array.Find(particles, particles => particles.name == name);
        }

        public void PlayEffect(string name, Transform _transform)
        {
            var particle = searchForEffect(name);
            Instantiate(particle.particle, _transform.position, Quaternion.identity);
        }

        public void PlayEffect(string name)
        {
            var particle = searchForEffect(name);
             Instantiate(particle.particle, transform.position, Quaternion.identity);


        }

        public void PlayEffectInDefualtPos(string name)
        {
            var particle = searchForEffect(name);
            Instantiate(particle.particle, particle.defaultPlayPos.position, Quaternion.identity);
            
        }
    }
}