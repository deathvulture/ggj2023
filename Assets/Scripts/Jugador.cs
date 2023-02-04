using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Jugador : MonoBehaviour
{
    public float fuerzaSalto;
    private Rigidbody2D rigid2D;
    public BoxCollider2D col;
    public CapsuleCollider2D col2;
    private Keyboard controlls;
    private bool onFloor = false;
    private Animator anim;
    

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        col.GetComponent<BoxCollider2D>();
        col2.GetComponent<CapsuleCollider2D>();
        controlls = Keyboard.current;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(onFloor)
        {
            Jump();
            Slide();
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Suelo")
        {
            onFloor = true;
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Suelo")
            onFloor = false;
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
            anim.SetBool("estaSaltando", true);
            rigid2D.AddForce(new Vector2(0, fuerzaSalto));
            onFloor = false;
        }
        else
        {
            anim.SetBool("estaSaltando", false);
        }
    }

    void Slide()
    {
        if(controlls.shiftKey.isPressed)
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