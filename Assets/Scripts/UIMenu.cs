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
        AudioManager.instance.Stop("GameOver");
        AudioManager.instance.Stop("Victory");
        AudioManager.instance.Stop("BG1");
        AudioManager.instance.Stop("BG2");
        AudioManager.instance.bgmEnabled = false;
        AudioManager.instance.Play("MainMenu");
    }
   
    public void Play()
    {
        AudioManager.instance.Stop("GameOver");
        SceneManager.LoadScene("StoryBoard");
    }

    public void Replay()
    {
        AudioManager.instance.Stop("GameOver");
        SceneManager.LoadScene("Juego");
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