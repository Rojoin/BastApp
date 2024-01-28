using System;
using System.Collections.Generic;
using UnityEngine;

public class TendencyManager : MonoBehaviour
{
    [SerializeField] private List<TendencyObject> prefabTendecy;
    [SerializeField] private Transform buttonHolder;
    public Tendency currentTendency;

    private void Awake()
    {
        foreach (var tendencyObject in prefabTendecy)
        {
            if (tendencyObject.tendecy.hasBeenTwitted)
            {
                Destroy(tendencyObject.gameObject);
            }
            else
            {
                tendencyObject.isTendencyChoose.AddListener(SetCurrentTendency);
            }
        }
    }

    private void SetCurrentTendency(Tendency tendency)
    {
        currentTendency = tendency;
    }
}