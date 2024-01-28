using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwittChooser : MonoBehaviour
{
    public Tendency _tendency;
    [SerializeField] private List<RickyOptionObject> responseButton;

    private void Awake()
    {
        for (int i = 0; i < _tendency.possibleResponses.Count; i++)
        {
            responseButton[i].TwittSo = _tendency.possibleResponses[i];
            responseButton[i].isTwittChoose.AddListener(SetRickyTwitt);
        }
    }
    private void SetRickyTwitt(RickTwittSO rickTwittSo)
    {
        
    }
}
