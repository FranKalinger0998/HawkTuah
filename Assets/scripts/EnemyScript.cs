using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    public int level;
  
    private void Update()
    {
        transform.position = Vector3.left * enemyData.speedModifier * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Llama"))
        {
            other.gameObject.GetComponent<LlamaScript>().Kill();
        }
    }
}
