using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    
    public Image barraColeccionable;
    public float barraActual = 0f;
    public float barraMaxima = 255f;

    void Start()
    {
        
    }

    void Update()
    {
        BarraTotal();
    }

    public void BarraTotal()
    {
        barraActual = Jugador.barraMagia;
        if(Time.timeScale != 0)
        {
           barraColeccionable.fillAmount = barraActual / barraMaxima;
        }
    }
}
