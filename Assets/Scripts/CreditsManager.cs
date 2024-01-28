using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditsManager : MonoBehaviour
{
    public EndingSelector endingSelector;
    public Image imagen;
    public TextMeshProUGUI texto;
    public Sprite imagenFinalBueno;
    public Sprite imagenFinalMalo;
    public Sprite imagenPerdiste;

    void Start()
    {
        if (imagen != null && texto != null)
        {
            MostrarSegunEstado();
        }
        else
        {
            UnityEngine.Debug.LogError("EndingSelector, Image o Text no inicializados en CreditsManager");
        }
    }

    // Esta función se llamará desde otro script y recibirás el estado como parámetro
    public void MostrarSegunEstado()
    {
        switch (endingSelector.ending)
        {
            case Endings.MIAMI_ENDING:
                imagen.sprite = imagenFinalBueno;
                texto.text = "\"Has cumplido la prueba satisfactoriamente al demostrar tu buena fama. Eres merecedor de volver a MIAMEEEEE.\"";
                break;
            case Endings.COMANDANTE_ENDING:
                imagen.sprite = imagenFinalMalo;
                texto.text = "\"Ricardo Fort se hizo tan famoso que se volvió el líder supremo. Desafiando a Jesús, ricky elijió la vida eterna.\"";
                break;
            case Endings.LOST:
                imagen.sprite = imagenPerdiste;
                texto.text = "\"Hijo mío, no te merecen... Vuelve a mis brazos y descansa en paz.\"";
                break;
            default:
                UnityEngine.Debug.LogError("Estado desconocido: " + endingSelector.ending.ToString());
                break;
        }
    }
}
