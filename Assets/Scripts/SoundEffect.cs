
using UnityEngine;
using Random = System.Random;
[System.Serializable]
public class SoundEffect 
{

    public AudioClip[] clips;
    [Range(0, 2)]
    public float pitch = 1;

    public AudioSource source;

    public string name;
    
 


    public AudioClip getRandomClip()
    {
        Random rand = new Random();
        return clips[rand.Next(clips.Length - 1)];
    }

    public AudioClip getFirstClip()
    {
        return clips[0];
    }

    public void play()
    {
        source.clip = getFirstClip();
        source.pitch = pitch;
        if (!source.isPlaying)
        source.Play();
    }

    public void stop()
    {
        if (source.isPlaying)
            source.Stop();
    }
}
