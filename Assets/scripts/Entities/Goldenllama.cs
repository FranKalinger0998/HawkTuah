using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goldenllama : MonoBehaviour
{
    int baseAmountGenerated=5;
    int amountGenerated;
    int moneyGenerationInterval=5;
    [SerializeField] LlamaScript llamaScript;
    [SerializeField] GameObject coinPrefab;
    void Start()
    {
        amountGenerated=baseAmountGenerated*llamaScript.level;
        StartCoroutine(GoldenLlamaGenerator());
    }

    IEnumerator GoldenLlamaGenerator()
    {
        yield return new WaitForSeconds(moneyGenerationInterval);
        GameManager.Instance.AddMoney(amountGenerated);
        Instantiate(coinPrefab, transform.position + Vector3.up*2, coinPrefab.transform.rotation, transform);
        coinPrefab.GetComponent<CoinScript>().SetIncomeText($"+{amountGenerated.ToString()}");
    }
    
}
