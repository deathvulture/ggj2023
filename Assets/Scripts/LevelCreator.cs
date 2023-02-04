using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameObject[] floorPrefabs;
    public GameObject[] backgrounds;
    public GameObject lastBG;
    public GameObject currentBG;
    public GameObject nextBg;
    private float offSet = 20.48f;
    private GameManager gm;
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
    void FixedUpdate()
    {
        MoveBackgrounds();
        ManageBackgrounds();
    }

    GameObject GetNextBackground()
    {
        return GameObject.Instantiate(backgrounds[Mathf.RoundToInt(Random.Range(0, backgrounds.Length))]);
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
            Object.Destroy(lastBG);
            lastBG = currentBG;
            currentBG = nextBg;
            nextBg = GetNextBackground();
            nextBg.transform.position = new Vector3(currentBG.transform.position.x + offSet, 0, 0); 
        }            
    }
}

