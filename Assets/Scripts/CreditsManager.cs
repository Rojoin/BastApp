using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public EndingSelector endingSelector;
    public Image imagen;
    public Sprite imagenFinalBueno;
    public Sprite imagenFinalMalo;
    public Sprite imagenPerdiste;

    void Start()
    {
        if (imagen != null)
        {
            MostrarImagenSegunEstado();
        }
        else
        {
            UnityEngine.Debug.LogError("EndingSelector o Image no inicializados en CreditsManager");
        }
    }

    // Esta función se llamará desde otro script y recibirás el estado como parámetro
    public void MostrarImagenSegunEstado()
    {
        switch (endingSelector.ending)
        {
            case Endings.MIAMI_ENDING:
                imagen.sprite = imagenFinalBueno;
                break;
            case Endings.COMANDANTE_ENDING:
                imagen.sprite = imagenFinalMalo;
                break;
            case Endings.LOST:
                imagen.sprite = imagenPerdiste;
                break;
            default:
                UnityEngine.Debug.LogError("Estado desconocido: ");
                break;
        }
    }
}