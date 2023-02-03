using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jugador : MonoBehaviour
{
    public float fuerzaSalto;
    public float tiempoDeslizando;
    private Rigidbody2D rigid2D;
    public BoxCollider2D col;
    public CapsuleCollider2D col2;
    
   
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        col.GetComponent<BoxCollider2D>();
        col2.GetComponent<CapsuleCollider2D>();
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
            
            if(Input.GetKey(KeyCode.C))
            {
                col2.enabled = true;
                col.enabled = false;
            }
            else{
                col2.enabled = false;
                col.enabled = true;
            }
        }
    }
}