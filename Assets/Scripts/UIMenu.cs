using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    private void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
   
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
  
    public void ResumeGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        Application.Quit();
    }
}