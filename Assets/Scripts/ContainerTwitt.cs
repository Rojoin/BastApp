using System;
using System.Collections;
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
    [SerializeField] public TwittSO _twittSo;

    public TwittSO twittSo
    {
        get => _twittSo;
        set
        {
            _twittSo = value;
            ChangeTwitt();
        }
    }

    [SerializeField] private int imageSpacing = 200;
    [SerializeField] private Vector2 defaultTwittSize;
    [SerializeField] public Toggle isLikedButton;
    [SerializeField] public Toggle isRetwitedButton;
    private bool isLiked;
    private bool isRetwited;
    private RectTransform _transform;

    private void OnValidate()
    {
        if (_twittSo != null)
        {
            ChangeTwitt();
        }
    }


    public void ChangeTwitt()
    {
        _transform = GetComponent<RectTransform>();
        userIcon.sprite = twittSo.userIcon;
        userName.text = twittSo.userName;
        textContainer.text = twittSo.prompt;
        if (twittSo.imageTwitt != null)
        {
            imageTwitt.sprite = twittSo.imageTwitt;
            _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, defaultTwittSize.y + imageSpacing);
            imageTwitt.gameObject.SetActive(true);
        }
        else
        {
            imageTwitt.sprite = null;
            imageTwitt.gameObject.SetActive(false);
            _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, defaultTwittSize.y);
        }

        isLiked = false;
        isRetwited = false;
    }
}