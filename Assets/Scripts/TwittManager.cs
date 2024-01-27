using System.Collections.Generic;
using UnityEngine;

public class TwittManager : MonoBehaviour
{
    [SerializeField] private List<ContainerTwitt> twittsContainer;
    [SerializeField] public List<TwittSO> TwittsToShow;

    public void UpdateTwitts()
    {
        for (int i = 0; i < twittsContainer.Count; i++)
        {
            twittsContainer[i].twittSo = TwittsToShow[i];
        }
    }

}