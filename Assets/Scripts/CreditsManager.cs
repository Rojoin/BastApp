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

    // Esta funci�n se llamar� desde otro script y recibir�s el estado como par�metro
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
                texto.text = "\"Ricardo Fort se hizo tan famoso que se volvi� el l�der supremo. Desafiando a Jes�s, ricky eliji� la vida eterna.\"";
                break;
            case Endings.LOST:
                imagen.sprite = imagenPerdiste;
                texto.text = "\"Hijo m�o, no te merecen... Vuelve a mis brazos y descansa en paz.\"";
                break;
            default:
                UnityEngine.Debug.LogError("Estado desconocido: " + endingSelector.ending.ToString());
                break;
        }
    }
}
