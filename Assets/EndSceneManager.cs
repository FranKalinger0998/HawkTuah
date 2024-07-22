using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndSceneManager : MonoBehaviour
{
    public VideoPlayer vid;
    public GameObject endGamePanel;
    private void Start()
    {

        StartCoroutine(IsRunning());  
        
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnQuitGame()
    {
        Application.Quit();
    }

    IEnumerator IsRunning()
    {


        yield return new WaitForSeconds(22);
        Debug.Log("in");
        endGamePanel.SetActive(true);
    }
}
