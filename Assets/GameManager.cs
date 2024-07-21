using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    int vaweCount;
    int money;
    bool isGameRunning;
    int Lifes;
    int MaxLifes=5;
    


    public TMP_Text MoneyText;
    public Image HealthImage;

    private void Awake()
    {
        Instance = this;
        Lifes=MaxLifes;
    }
    
    public void RemoveLife()
    {
        Lifes--;
        HealthImage.fillAmount = (float)Lifes/(float)MaxLifes ;
        if ( Lifes <= 0 ) 
        {
            SceneManager.LoadScene("EndScrene");
        }
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
        MoneyText.text="Gold: " + money.ToString();
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
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
