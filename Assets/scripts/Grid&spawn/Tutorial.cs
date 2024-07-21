using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] TMP_Text instructionText;
    [SerializeField] string[] instructionTexts;
    [SerializeField] GameObject[] circles;
    int instructionCount=0;
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    public void GoThroughTutorial()
    {
        if(instructionCount == 15)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("GamePlay");

        }
        instructionText.text = instructionTexts[instructionCount];
        if(instructionCount == 2)
        {
            circles[0].SetActive(true);
        }
        else if(instructionCount == 3)
        {
            circles[0].SetActive(false);
        }
        else if(instructionCount == 5)
        {
            circles[1].SetActive(true);
        }
        else if(instructionCount == 6)
        {
            circles[2].SetActive(true);
            circles[1].SetActive(false);
        }
        else if(instructionCount == 7)
        {
            circles[3].SetActive(true);
            circles[2].SetActive(false);
        }
        else if(instructionCount == 9)
        {
            circles[4].SetActive(true);
            circles[3].SetActive(false);
        }
        else if(instructionCount==10)
        {
            circles[5].SetActive(true);
            circles[4].SetActive(false);
        }
        else if(instructionCount == 12)
        {
            circles[6].SetActive(true);
            circles[5].SetActive(false);
        }
        else if(instructionCount == 13)
        {
            circles[6].SetActive(false);
        }

        instructionCount++;
    }
}
