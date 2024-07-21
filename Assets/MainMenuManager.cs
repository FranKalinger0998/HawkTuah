using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void OnPlay()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void OnTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void OnQuitGame()
    {
        Application.Quit();
    }

}
