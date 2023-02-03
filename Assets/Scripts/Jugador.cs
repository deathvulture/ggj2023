using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Jugador : MonoBehaviour
{
    public float fuerzaSalto;
    private Rigidbody2D rigid2D;
   
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
  
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            if(Input.GetKey(KeyCode.Space))
            {
                rigid2D.AddForce(new Vector2(0, fuerzaSalto));  
            }
        }
    }
}