using UnityEngine.SceneManagement;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public GameObject[] Images;
    public float timeBetweenImages = 2000f;
    public int currentImageIndex = 0;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timeBetweenImages;
        AudioManager.instance.Stop("MainMenu");
        AudioManager.instance.Play("StoryBoard");
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime * 1000;
        if (timer <= 0)
        {
            if (currentImageIndex == Images.Length -1)
            {
                SceneManager.LoadScene("Juego");
                return;
            }

            Images[currentImageIndex + 1].SetActive(true);
            Images[currentImageIndex].SetActive(false);
            timer = timeBetweenImages;
            currentImageIndex += 1;
        }
    }
}
