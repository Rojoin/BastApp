using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    private Toggle button;
    public Sprite isOn;
    public Sprite isOff;
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
    }
}