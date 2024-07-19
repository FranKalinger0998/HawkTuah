using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    public int level;
    float currentHealth;
    float slowDownMod=0.8f;

    private void Start()
    {
        currentHealth=enemyData.health*level;
    }
    private void Update()
    {
        transform.position += Vector3.left * enemyData.speedModifier * slowDownMod * Time.deltaTime;
        KillIfDead();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Llama"))
        {
            other.gameObject.GetComponent<LlamaScript>().Kill();
        }
        else if(other.gameObject.CompareTag("Spittle"))
        {
            LlamaScript reference = other.gameObject.GetComponent<SpitScript>().spitSender.GetComponent<LlamaScript>();
            int damage = reference.damage;
            if(reference.lamaType==LamaType.White)
            {
                currentHealth -= damage;
                Destroy(other.gameObject);
            }
            else if (reference.lamaType == LamaType.Green)
            {
                StartCoroutine(DoT(damage));
                Destroy(other.gameObject);
                
            }
            else
            {
                slowDownMod = 0.4f;
            }
        }
    }
    void KillIfDead()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator DoT(int damage)
    {
        while(currentHealth > 0)
        {
            yield return new WaitForSeconds(1);
            currentHealth -= damage;
            Debug.Log(currentHealth);
        }  

    }
}
