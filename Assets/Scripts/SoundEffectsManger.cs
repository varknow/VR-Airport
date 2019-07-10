using System;
using UnityEngine;
[Serializable]
public class SoundEffectsManger : MonoBehaviour
{
    public SoundEffect[] Effcets;

    public void play(string n)
    {
        var effect = Array.Find(Effcets, Effects => Effects.name == n);
        effect.play();

    }

    public void stop(string n)
    {
        var effect = Array.Find(Effcets, Effects => Effects.name == n);
        effect.stop();
    }

    internal void play(int index)
    {
        throw new NotImplementedException();
    }
}
