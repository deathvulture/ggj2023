using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float gameSpeed = 1;
    public float speedMultiplier = 0.01f;
    public bool trapSpawned = false;
    public float timeBeforNextSpawn = 3000f;
    public float limpieza = 0f;

    void Awake()
    {
        if ( instance == null )
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        
    }


}
