using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    public int level;
    float currentHealth;
    float slowDownMod=0.8f;
    int poisonTick = 0;
    EnemyHit enemyHitSimulator;
    bool reachedLama;

    private void Start()
    {
        enemyHitSimulator=GetComponent<EnemyHit>();
        currentHealth =enemyData.health*level;
    }
    private void Update()
    {
        if (!reachedLama)
        {
            transform.position += Vector3.left * enemyData.speedModifier * slowDownMod * Time.deltaTime;
        } 
        KillIfDead();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Llama"))
        {
            if(!other.gameObject.GetComponent<LlamaScript>().isdead) 
            {
                reachedLama = true;
                other.gameObject.GetComponent<LlamaScript>().Kill();
                StartCoroutine(WaitForFiveSeconds());
            }
            
        }
        else if(other.gameObject.CompareTag("Spittle"))
        {
            LlamaScript reference = other.gameObject.GetComponent<SpitScript>().spitSender.GetComponent<LlamaScript>();
            int damage = reference.damage;
            if(reference.lamaType==LamaType.Red)
            {
                currentHealth -= damage;
                enemyHitSimulator.DamageEnemyEffects();
                Destroy(other.gameObject);
            }
            else if (reference.lamaType == LamaType.Green)
            {
                StartCoroutine(DoT(damage));
                Destroy(other.gameObject);
                
            }
            else if (reference.lamaType == LamaType.Blue)
            {
                currentHealth -= damage;
                enemyHitSimulator.DamageEnemyEffects();
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
        while(currentHealth > 0 && poisonTick<3)
        {
            yield return new WaitForSeconds(1);
            currentHealth -= damage;
            enemyHitSimulator.DamageEnemyEffects();
            poisonTick++;
            //Debug.Log(currentHealth);
        }  

    }
    IEnumerator WaitForFiveSeconds()
    {
        int i = 0;
        while(true)
        {
            yield return new WaitForSeconds(1);
            i++;
            if (i == 5)
            {
                reachedLama=false;
            }
        }
        
    }
}
