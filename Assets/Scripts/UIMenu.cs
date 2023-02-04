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
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
  
    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}