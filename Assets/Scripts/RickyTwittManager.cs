using UnityEngine;

public class RickyTwittManager : TwittManager
{
    [SerializeField] public RickTwittSO currentTwitt;

    public override void UpdateTwitts()
    {
        for (int i = 0; i < twittsContainer.Count; i++)
        {
            twittsContainer[i].twittSo = i == 0 ? currentTwitt : currentTwitt.posibleTwitts[i-1];
            twittsContainer[i].ChangeTwitt();
        }
    }
}