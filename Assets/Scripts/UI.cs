using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        barraColeccionable.fillAmount = GameManager.instance.limpieza;
    }
}
