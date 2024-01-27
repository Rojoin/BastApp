using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Tendency", fileName = "Tendency", order = 0)]
public class Tendency : ScriptableObject
{
    [Header("name")]
    public string tendencyName;
    [Header("Related Tweets")]
    public List<TwittSO> relatedTweets = new List<TwittSO>();
    [Header("Possible Responses")]
    public List<RickTwittSO> possibleResponses = new List<RickTwittSO>();
}
