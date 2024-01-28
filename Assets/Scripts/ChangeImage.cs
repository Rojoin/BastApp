using UnityEngine;
using UnityEngine.UI;

public enum ImageType
{
    HEART = 0,
    RETWEET
}

public class ChangeImage : MonoBehaviour
{
    private Toggle button;
    public Sprite isOn;
    public Sprite isOff;
    public ImageType imageType;

    private void Awake()
    {
        button = GetComponent<Toggle>();
        button.onValueChanged.AddListener(ChangeImageButton);
    } 
    private void OnDestroy()
    {
        button.onValueChanged.RemoveListener(ChangeImageButton);
    }

    private void ChangeImageButton(bool value)
    {
        button.image.sprite = value ? isOn : isOff;

        string sound = "";

        switch(imageType) { 
            case ImageType.RETWEET:
                sound = "Retweet";
                break;
            case ImageType.HEART:
                sound = "Like";
                break;
        }

        FindObjectOfType<AudioManager>().Play(sound);
    }
}