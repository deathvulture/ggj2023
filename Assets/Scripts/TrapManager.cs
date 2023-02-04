using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }


    public float minTrapSpawnTime = 5000f;
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> trapPoolDict;

    // Start is called before the first frame update
    void Start()
    {
        
        trapPoolDict = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject trap = Instantiate(pool.prefab);
                trap.SetActive(false);
                objectPool.Enqueue(trap);
            }

            trapPoolDict.Add(pool.tag, objectPool);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.timeBeforNextSpawn -= Time.deltaTime * 1000;
        if (GameManager.instance.timeBeforNextSpawn <= 0)
        {
            GameManager.instance.timeBeforNextSpawn = minTrapSpawnTime + Mathf.RoundToInt(Random.Range(0, 3000));
            TrapSpawner("Trampa" + Mathf.RoundToInt(Random.Range(1, 3)));
        }
    }

    void TrapSpawner(string trapType)
    {
        GameObject nextTrap = trapPoolDict[trapType].Dequeue();
        nextTrap.SetActive(true);
        nextTrap.transform.position = new Vector3(12, nextTrap.transform.position.y, 0);
        trapPoolDict[trapType].Enqueue(nextTrap);
        GameManager.instance.trapSpawned = true;
    }


}
