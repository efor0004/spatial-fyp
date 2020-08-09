using UnityEngine;
using UnityEngine.Audio;
using System;

//Music and Sound Effects Credit 
// background music: https://freesound.org/people/FoolBoyMedia/sounds/264295/
// tap: https://freesound.org/people/kwahmah_02/sounds/256116/
// successul placement: https://freesound.org/people/shinephoenixstormcrow/sounds/337049/
// end of puzzle: https://freesound.org/people/LittleRobotSoundFactory/sounds/270404/

public class AudioManager : MonoBehaviour
{
    // manages sounds
    // adapted from https://www.youtube.com/watch?v=6OT43pvUyfY

    public Sound[] sounds;

    public static AudioManager instance; //static reference to current instance of audiomanager

    void Awake()
    {
        //called before start

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; 
        }

        DontDestroyOnLoad(gameObject); 


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop; 
        }
        
    }

    private void Start()
    {
        if (Global.Music == true)
            Play("BackgroundMusic"); 
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);   //finding sound in sound array by name
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!"); 
            return;
        }
        s.source.Play(); 
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);   //finding sound in sound array by name
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
