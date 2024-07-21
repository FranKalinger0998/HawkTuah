using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript Instance;
    public AudioSource lamaSpit;
    public AudioSource uff;
    [SerializeField] AudioSource bgm;

    private void Awake()
    {
        Instance = this;
    }
    
    public void PlayLamaSpit()
    {
        lamaSpit.Play();
    }
    public void PlayUffSound()
    {
        uff.Play();
    }
    public void MuteSound()
    {
        bgm.Pause();
    }
    public void BringBackSound()
    {
        bgm.UnPause();
    }
}
