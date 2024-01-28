using UnityEngine;

public class TendecyTwittManager : TwittManager
{
    [SerializeField] public Tendency tendency;

    public override void UpdateTwitts()
    {
        for (int i = 0; i < twittsContainer.Count; i++)
        {
            twittsContainer[i].twittSo =  tendency.relatedTweets[i];
            twittsContainer[i].ChangeTwitt();
        }
    }
}