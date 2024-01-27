using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ContainerTwitt : MonoBehaviour
{
    [SerializeField] private SpriteRenderer userIcon;
    [SerializeField] public TextMeshProUGUI userName;
    [SerializeField] public TextMeshProUGUI textContainer;
    [SerializeField] private SpriteRenderer imageTwitt;
    [SerializeField] private Twitt twitt;
}