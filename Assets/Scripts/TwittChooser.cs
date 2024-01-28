using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TwittChooser : MonoBehaviour
{
    public Tendency _tendency;
    [SerializeField] private List<RickyOptionObject> responseButton;
    public UnityEvent<RickTwittSO> onTwittChoosed;

    private void Awake()
    {
        for (int i = 0; i < _tendency.possibleResponses.Count; i++)
        {
            responseButton[i].TwittSo = _tendency.possibleResponses[i];
            responseButton[i].isTwittChoose.AddListener(SetRickyTwitt);
            responseButton[i].gameObject.SetActive(true);
        }
    }
    private void SetRickyTwitt(RickTwittSO rickTwittSo)
    {
        onTwittChoosed.Invoke(rickTwittSo);
        FindObjectOfType<AudioManager>().Play("Send");
    }
}
