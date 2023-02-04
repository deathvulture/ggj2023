using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Jugador : MonoBehaviour
{
    public float fuerzaSalto;
    public float tiempoDeslizando;
    private Rigidbody2D rigid2D;
    public BoxCollider2D col;
    public CapsuleCollider2D col2;
    private Keyboard controlls;
    

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        col.GetComponent<BoxCollider2D>();
        col2.GetComponent<CapsuleCollider2D>();
        controlls = Keyboard.current;
    }

    void Update()
    {
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
        Jump();
        Slide();        
        }
    }

    void Jump()
    {
        if(controlls.spaceKey.isPressed)
        {
        rigid2D.AddForce(new Vector2(0, fuerzaSalto)); 
        }
    }

    void Slide()
    {
        if(controlls.shiftKey.isPressed)
            {
                col2.enabled = true;
                col.enabled = false;
                Debug.Log("estas aprentando Shift");
            }
            else{
                col2.enabled = false;
                col.enabled = true;
            }
    }
}