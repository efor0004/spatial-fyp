﻿using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    // lists sounds
    // enter values in user interface of Unity 
    // adapted from https://www.youtube.com/watch?v=6OT43pvUyfY

    public string name; 

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop; 

    [HideInInspector]
    public AudioSource source; 
}
