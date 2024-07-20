using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    int vaweCount;
    int money;
    bool isGameRunning;

    public TMP_Text MoneyText;

    private void Awake()
    {
        Instance = this;
    }
    public void AddMoney(int amount)
    {
        money += amount;
    }
    public bool TrySpendMoney(int amount)
    {

        if (money >= amount)
        {
            money -= amount;
            UpdateUI();
            return true;
            
        }
        else 
        {
            return false;
        }
    }
    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGameRunning = true;
        StartCoroutine(PeriodicIncrement());
    }
    void UpdateUI()
    {
        MoneyText.text=money.ToString();
    }
    public IEnumerator PeriodicIncrement()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(1);
            money += ShopController.Instance.shopLevel;
            UpdateUI();
        }
    }

}
