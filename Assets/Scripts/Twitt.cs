using UnityEngine;

[CreateAssetMenu(menuName = "Create Twitt", fileName = "Twitt", order = 0)]
public class Twitt : ScriptableObject
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