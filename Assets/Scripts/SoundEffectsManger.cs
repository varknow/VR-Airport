using System;
using UnityEngine;
[Serializable]
public class SoundEffectsManger : MonoBehaviour
{
    public SoundEffect[] Effcets;

    public SoundEffect play(string n)
    {
        var effect = Array.Find(Effcets, Effects => Effects.name == n);
        effect.play();
        return effect;

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
    
    public void PlayDialogueSound(string name)
    {
        var effect = play(name);
        FindObjectOfType<DialogueManager>().soundClip = effect.clips[0];
    }
}
