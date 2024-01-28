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
        Init();
    }

    public void Init()
    {
   

        var counter = 0;
        foreach (var tendencyObject in prefabTendecy)
        {
            if (tendencyObject != null)
            {
                if (tendencyObject.tendecy.hasBeenTwitted)
                {
                    Destroy(tendencyObject.gameObject);
                    counter++;
                }
                else
                {
                    tendencyObject.isTendencyChoose.AddListener(SetCurrentTendency);
                }
            }
            else
            {
                counter++;
                Debug.Log(counter);
            }
        }

        if (counter == prefabTendecy.Count)
        {
            activateEnding.Invoke();
            Debug.Log("Ending");
        }
    }

    private void SetCurrentTendency(Tendency tendency)
    {
        currentTendency = tendency;
        tendency.hasBeenTwitted = true;
        chooseTendency.Invoke();
        FindObjectOfType<AudioManager>().Play("click");
    }
}