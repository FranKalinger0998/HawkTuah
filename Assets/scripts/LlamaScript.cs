using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LlamaScript : MonoBehaviour
{
    [SerializeField] LlamaData llamaData;
    [SerializeField] GameObject phlegmPrefab;
    public int level=1;
    bool isdead;
    private void Start()
    {
        StartCoroutine(SpitFire());
        RespawnLama();
        //Kill();
    }

    public void Kill()
    {
        isdead = true;
    }

    public void RespawnLama()
    {
        isdead=false;
        StartCoroutine(SpitFire());
    }



    IEnumerator SpitFire()
    {
        while (!isdead) 
        {
            yield return new WaitForSeconds(level * 1f * llamaData.baseFireSpeed);
            Instantiate(phlegmPrefab, gameObject.transform.GetChild(0).transform.position, Quaternion.identity);
            Debug.Log("Hawk tuak" + level * 1f * llamaData.baseFireSpeed);
        }
        
    }

}
