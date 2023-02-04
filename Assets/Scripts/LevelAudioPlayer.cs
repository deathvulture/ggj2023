using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAudioPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("play music");
        AudioManager.instance.PlayLevelMusic();
    }


}
