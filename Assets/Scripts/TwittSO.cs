using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Create TwittSO", fileName = "Twitt", order = 0)]
[Serializable]
public class TwittSO : ScriptableObject
{
    [Header("User")]
    public string userName;
    public Sprite userIcon;
    [Header("TwittDetails")]
    public string prompt;
    public Sprite imageTwitt;
    [Header("Points")]
    public int followPoints;
    public int repPoints;

    [Header("Variables")] 
    public bool isLiked = false;
    public bool isRetwitted = false;

    public void Reset()
    {
        isLiked = false;
        isRetwitted = false;
    }
}