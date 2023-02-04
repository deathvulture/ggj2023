using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public const float initialOffset = 7.89f;
    public const float verticalOffset = 3.9f;
    private int startingFloorQty = 10;
    private int lastIndex = -5;
    private int coolDown = 0;


    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> floorPoolDict;
    public GameObject lastFloor;

    // Start is called before the first frame update
    void Start()
    {
        floorPoolDict = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject trap = Instantiate(pool.prefab);
                trap.SetActive(false);
                objectPool.Enqueue(trap);
            }

            floorPoolDict.Add(pool.tag, objectPool);
        }
        InitializeFloor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void InitializeFloor()
    {
        for (int i = 0; i < startingFloorQty; i++)
        {
            GameObject tile = SpawnFloor("Piso" + Mathf.RoundToInt(Random.Range(1, 6)));
            tile.transform.position = new Vector3((2f * i) - initialOffset, -verticalOffset, 0);
            lastFloor = tile;
        }
    }

    GameObject SpawnFloor(string floorType)
    {
        GameObject nextTrap = floorPoolDict[floorType].Dequeue();
        nextTrap.SetActive(true);
        nextTrap.transform.position = new Vector3(20, nextTrap.transform.position.y, 0);
        floorPoolDict[floorType].Enqueue(nextTrap);
        return nextTrap;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Suelo")
        {
            int randomIndex = lastIndex;
            if (GameManager.instance.trapSpawned)
            {
                coolDown = 2;
            }

            while (randomIndex == lastIndex)
            {
                randomIndex = Mathf.RoundToInt(Random.Range(1, 7));
                if (randomIndex == 6 && coolDown != 0)
                    randomIndex = lastIndex;
            }

            coolDown -= 1;
            GameManager.instance.trapSpawned = false;
            lastIndex = randomIndex;
            GameObject tile = SpawnFloor("Piso" + randomIndex); ;
            tile.transform.position = new Vector3(lastFloor.transform.position.x + 2, -verticalOffset, 0);
            lastFloor = tile;

            if (randomIndex == 6)
                GameManager.instance.timeBeforNextSpawn += 2000;
        }
    }
}
