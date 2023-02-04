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
    public bool isDead = false;
    private Animator anim;
    private bool pauseActive;
    public static float barraMagia = 255f;
    public GameObject deadMenu;

    void Start()
    {
        barraMagia = 255f;
        isDead = false;
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
                anim.SetBool("estaDeslizandose", true);
                col2.enabled = true;
                col.enabled = false;
            }
            else{
                anim.SetBool("estaDeslizandose", false);
                col2.enabled = false;
                col.enabled = true;
            }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Trampa")
        {
            MuerteJugador();
        }

        if(col.gameObject.tag == "Magia")
        {
            barraMagia = -5f;
        }
    }
    void MuerteJugador()
    {
        if(!isDead)
        {
            isDead = true;
            anim.SetBool("estaMuerto", true);
            deadMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            isDead = false;
            Time.timeScale = 1;
            deadMenu.SetActive(false);
            anim.SetBool("estaMuerto", false);
        }
    }  
}