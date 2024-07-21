using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnQuitGame()
    {
        Application.Quit();
    }
}
