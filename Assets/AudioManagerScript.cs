using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript Instance;
    public AudioSource lamaSpit;

    private void Awake()
    {
        Instance = this;
    }
    
    public void PlayLamaSpit()
    {
        lamaSpit.Play();
    }
}
