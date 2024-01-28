using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RickyOptionObject : MonoBehaviour
{
    public RickTwittSO TwittSo;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI tendencyText;
    [SerializeField] public UnityEvent<RickTwittSO> isTwittChoose;

    private void Awake()
    {
        button.onClick.AddListener(PressButton);
        tendencyText.text = TwittSo.optionPrompt;
    }

    private void PressButton()
    {
        isTwittChoose.Invoke(TwittSo);
    }

    private void OnEnable()
    {
        tendencyText.text = TwittSo.optionPrompt;
    }

    private void OnDisable()
    {
        isTwittChoose.RemoveAllListeners();
    }
}