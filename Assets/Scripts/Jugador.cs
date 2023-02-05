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
    public static float barraMagia = 0f;
    public GameObject deadMenu;
    public float tiempoDeslizado = 500f;
    public float cooldown = 200f;

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

    void Jump()
    {
        if(controlls.spaceKey.isPressed && !controlls.shiftKey.isPressed)
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
        if(controlls.shiftKey.isPressed && !controlls.spaceKey.isPressed && tiempoDeslizado > 0)
            {
                tiempoDeslizado -= Time.deltaTime * 1000;
                anim.SetBool("estaDeslizandose", true);
                col2.enabled = true;
                col.enabled = false;
            }
            else{
                anim.SetBool("estaDeslizandose", false);
                col2.enabled = false;
                col.enabled = true;
                if(tiempoDeslizado < 0)
                {
                    cooldown -= Time.deltaTime * 1000;
                    if(cooldown <= 0)
                    {
                        tiempoDeslizado = 500f;
                        cooldown = 200f;
                    }
                }
                else{
                    tiempoDeslizado = 500f;
                    cooldown = 200f;
                }
            }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Trampa")
        {
            MuerteJugador();
        }
        Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag == "Magia")
        {
            GameManager.instance.limpieza += 0.05f;
            Destroy(col.gameObject);
        }
    }
    void MuerteJugador()
    {
        if(!isDead)
        {
            isDead = true;
            deadMenu.SetActive(true); 
        }
        else
        {
            isDead = false;
            deadMenu.SetActive(false);
        }
    }  
}