using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ContainerTwitt : MonoBehaviour
{
    [SerializeField] private Image userIcon;
    [SerializeField] public TextMeshProUGUI userName;
    [SerializeField] public TextMeshProUGUI textContainer;
    [SerializeField] private Image imageTwitt;
    [SerializeField] private Twitt twitt;
    [SerializeField] private int imageSpacing = 200;
    [SerializeField] private Vector2 defaultTwittSize;

    private RectTransform _transform;

    private void OnValidate()
    {
        _transform = GetComponent<RectTransform>();
        userIcon.sprite = twitt.userIcon;
        userName.text = twitt.userName;
        textContainer.text = twitt.prompt;
        if (twitt.imageTwitt != null)
        {
            imageTwitt.sprite = twitt.imageTwitt;
            _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,defaultTwittSize.y + imageSpacing);
            imageTwitt.gameObject.SetActive(true);
        }
        else
        {
            imageTwitt.sprite = null;
            imageTwitt.gameObject.SetActive(false);
            _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,defaultTwittSize.y);
        }
    }
}