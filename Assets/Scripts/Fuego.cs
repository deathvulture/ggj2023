using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    public float speed = 2f;
    public float range = 0.5f;
    private int currentDirection = -1;
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Time.deltaTime * -GameManager.instance.gameSpeed;
        if (Mathf.Abs(transform.position.y - originalPos.y) > range)
            currentDirection *= -1;

        float ySpeed = Time.deltaTime * speed * currentDirection;
        transform.Translate(new Vector3( xSpeed, ySpeed, 0));
    }
}
