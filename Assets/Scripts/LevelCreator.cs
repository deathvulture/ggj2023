using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LevelCreator : MonoBehaviour
{

    public GameObject[] floorPrefabs;
    public GameObject[] backgroundPrefabs;
    public GameObject[] trapPrefabs;
    public GameObject lastBG;
    public GameObject currentBG;
    public GameObject nextBg;
    public GameObject fueguito;
    public float fueguitoCD = 10000;
    public float timeToSpawnFuego;
    public GameObject luzObject;
    private Light2D luz;


    private const float offSet = 20.48f;
    private GameManager gm;
    


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        currentBG = GetNextBackground();
        nextBg = GetNextBackground();
        currentBG.transform.position = new Vector3(0, -0.1f, 0);
        nextBg.transform.position = new Vector3(offSet, -0.1f, 0);
        lastBG = new GameObject();
        timeToSpawnFuego = fueguitoCD;
        gm.limpieza = 0.05f;
        gm.gameSpeed = gm.originalGameSpeed;
        luz = luzObject.GetComponent<Light2D>();

}

    // Update is called once per frame
    void Update()
    {
        MoveBackgrounds();
        ManageBackgrounds();
        ManageFueguito();
        gm.gameSpeed += Time.deltaTime * 0.01f;
        luz.intensity = Mathf.Clamp(gm.limpieza + 0.2f, 0.2f, 1f);

        
    }

    GameObject GetNextBackground()
    {
        return GameObject.Instantiate(backgroundPrefabs[Mathf.RoundToInt(Random.Range(0, backgroundPrefabs.Length))]);
    }

    void MoveBackgrounds()
    {
        Vector3 direction = new Vector3(Time.deltaTime * gm.gameSpeed * -1, -0, 0);
        lastBG.transform.Translate(direction);
        currentBG.transform.Translate(direction);
        nextBg.transform.Translate(direction);
    }

    void ManageBackgrounds()
    {
        if (nextBg.transform.position.x <= 0)
        {
            Destroy(lastBG);
            lastBG = currentBG;
            currentBG = nextBg;
            nextBg = GetNextBackground();
            nextBg.transform.position = new Vector3(currentBG.transform.position.x + offSet, -0.1f, 0);
        }            
    }

    void ManageFueguito()
    {
        timeToSpawnFuego -= Time.deltaTime * 1000;
        if (timeToSpawnFuego <= 0)
        {
            timeToSpawnFuego = fueguitoCD;
            GameObject nuevoFuego = GameObject.Instantiate(fueguito);
        }
    }

}

