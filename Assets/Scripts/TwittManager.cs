using System.Collections.Generic;
using UnityEngine;

public abstract class TwittManager : MonoBehaviour
{
    [SerializeField] protected List<ContainerTwitt> twittsContainer;
    //[SerializeField] public Tendency tendency;

    [ContextMenu("Update Twitts")]
    public abstract void UpdateTwitts();
}