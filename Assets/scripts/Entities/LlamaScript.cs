using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LlamaScript : MonoBehaviour
{
    [SerializeField] LlamaData llamaData;
    [SerializeField] GameObject phlegmPrefab;
    
    public LamaType lamaType;
    public int level=1;
    public bool isdead;
    public int damage;
    private void Start()
    {
        if (llamaData.baseFireSpeed != 0)
        {
            StartCoroutine(SpitFire());
        }
        damage =llamaData.baseDamage*level;
        lamaType=llamaData.type;
    }

    public void Kill()
    {      
        StartCoroutine(GetTurnedOver());
    }

    public void RespawnLama(Component sender,object data)
    {
        if (data is int)
        {
            int value = (int)data;
            if (value == 0)
            {
                Debug.Log("Radi");
                if (isdead)
                {
                    transform.Rotate(0, 0, 180);
                }
                isdead = false;
                StopAllCoroutines();
                if(lamaType!=LamaType.Gold)
                {
                    StartCoroutine(SpitFire());
                }
                
            }
        }    
    }
    IEnumerator SpitFire()
    {
        while (!isdead) 
        {          
            GameObject temp = Instantiate(phlegmPrefab, gameObject.transform.GetChild(0).transform.position, phlegmPrefab.transform.rotation);
            //phlegmPrefab.GetComponent<SpitScript>().spitSender=gameObject;
            temp.GetComponent<SpitScript>().spitSender = gameObject;
            //Debug.Log(phlegmPrefab.GetComponent<SpitScript>().spitSender.name);
            
                yield return new WaitForSeconds(4f * (1 / llamaData.baseFireSpeed));          
        }
        
    }
    IEnumerator GetTurnedOver()
    {
        int i= 0;
        while (true) 
        {
            yield return new WaitForSeconds(1);
            i++;
            if(i==5)
            {
                isdead = true;
                transform.Rotate(0, 0, 180);
                break;
            }
        }
    }

}
