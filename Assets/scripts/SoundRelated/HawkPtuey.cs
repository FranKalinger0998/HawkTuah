using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HawkPtuey : MonoBehaviour
{
    [SerializeField] AudioSource source;
    public void SpitOnThatThang()
    {
        source.Play();
    }
}
