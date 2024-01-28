using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TendencyManager : MonoBehaviour
{
    [SerializeField] private List<TendencyObject> prefabTendecy;
    public Tendency currentTendency;
    public UnityEvent activateEnding;
    public UnityEvent chooseTendency;

    private void Awake()
    {
        if (prefabTendecy.Count < 0)
        {
            activateEnding.Invoke();
        }
        else
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
    }

    private void SetCurrentTendency(Tendency tendency)
    {
        currentTendency = tendency;
        tendency.hasBeenTwitted = true;
        chooseTendency.Invoke();
    }
}