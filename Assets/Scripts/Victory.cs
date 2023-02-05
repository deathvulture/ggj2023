using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public float timer = 5000;
    public GameObject imagen;
    public GameObject texto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime * 1000;
        if (timer <= 0)
        {
            imagen.SetActive(false);
            texto.SetActive(true);
        }
    }
}
