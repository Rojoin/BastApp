using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TendencyObject : MonoBehaviour
{
    public Tendency tendecy;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI tendencyText;
    [SerializeField] public UnityEvent<Tendency> isTendencyChoose;

  

    private void Awake()
    {
        button.onClick.AddListener(PressButton);
        tendencyText.text = tendecy.tendencyName;
    }

    private void PressButton()
    {
        isTendencyChoose.Invoke(tendecy);
    }

    private void OnDestroy()
    {
        isTendencyChoose.RemoveAllListeners();
    }
}