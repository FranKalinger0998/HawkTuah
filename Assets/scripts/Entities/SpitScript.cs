using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitScript : MonoBehaviour
{
    public GameObject spitSender;
    void Update()
    {
        transform.position += Vector3.right *2* Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Treshold"))
        {
            Destroy(gameObject);
        }
    }
}
