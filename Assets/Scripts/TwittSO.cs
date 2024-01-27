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
}