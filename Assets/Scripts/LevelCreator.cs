using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameObject[] floorPrefabs;
    public GameObject[] backgroundPrefabs;
    public GameObject[] trapPrefabs;
    public GameObject lastBG;
    public GameObject currentBG;
    public GameObject nextBg;

    public float minTrapSpawnTime = 2000f;
    public float timeBeforNextSpawn = 5000f;
    private const float offSet = 20.48f;
    private GameManager gm;
    private GameObject[] trapObjectPool;
    

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        currentBG = GetNextBackground();
        nextBg = GetNextBackground();
        currentBG.transform.position = new Vector3(0, 0, 0);
        nextBg.transform.position = new Vector3(offSet, 0, 0);
        lastBG = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackgrounds();
        ManageBackgrounds();
        ManageTraps();
    }

    GameObject GetNextBackground()
    {
        return GameObject.Instantiate(backgroundPrefabs[Mathf.RoundToInt(Random.Range(0, backgroundPrefabs.Length))]);
    }

    void MoveBackgrounds()
    {
        Vector3 direction = new Vector3(Time.deltaTime * gm.gameSpeed * -1, 0, 0);
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
            nextBg.transform.position = new Vector3(currentBG.transform.position.x + offSet, 0, 0);
        }            
    }

    void ManageTraps()
    {
        timeBeforNextSpawn -= Time.deltaTime * 1000;
        GameObject nextTrap = trapObjectPool[Mathf.RoundToInt(Random.Range(0, trapObjectPool.Length))];
        nextTrap.transform.position = new Vector3(30f, nextTrap.transform.position.y);


    }

    GameObject[] CreateTrapPool(int copies)
    {
        GameObject[] objectPool = new GameObject[copies * trapPrefabs.Length];
        for (int i = 0; i < trapPrefabs.Length; i++)
        {
            objectPool[i] = GameObject.Instantiate(trapPrefabs[i]);
            objectPool[i+1] = GameObject.Instantiate(trapPrefabs[i]);
            objectPool[i+2] = GameObject.Instantiate(trapPrefabs[i]);
        }
        return objectPool;
    }
}

