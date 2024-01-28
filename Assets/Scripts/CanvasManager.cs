using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private TendencyManager _tendencyManager;
    [SerializeField] private TendecyTwittManager _twittInTendencyManager;
    [SerializeField] private RickyTwittManager _twittsInResponseManager;
    [SerializeField] private TwittChooser _selectTwitt;
    [Header("Canvas")]
    [SerializeField] private CanvasGroup tendencyCanvas;
    [SerializeField] private CanvasGroup twittsInTendecyCanvas;
    [SerializeField] private CanvasGroup selectTwittCanvas;
    [SerializeField] private CanvasGroup twittsInResponseCanvas;
    [SerializeField] private CanvasGroup resultsScreenCanvas;
    [Header("Buttons")]
    [SerializeField] private Button openResponseButton;

    private RickTwittSO currentTwitt = null;

    private void Awake()
    {
        SetCanvasVisibility(tendencyCanvas, true);
        SetCanvasVisibility(twittsInTendecyCanvas, false);
        SetCanvasVisibility(selectTwittCanvas, false);
        SetCanvasVisibility(twittsInResponseCanvas, false);
        SetCanvasVisibility(resultsScreenCanvas, false);
        _tendencyManager.chooseTendency.AddListener(ShowTwittsInTendency);
        openResponseButton.onClick.AddListener(ShowSelectTwitt);
        _selectTwitt.onTwittChoosed.AddListener(ShowTwitsInResponse);
    }

    private void OnDisable()
    {
        _tendencyManager.chooseTendency.RemoveListener(ShowTwittsInTendency);
        openResponseButton.onClick.RemoveListener(ShowSelectTwitt);
        _selectTwitt.onTwittChoosed.RemoveListener(ShowTwitsInResponse);
    }

    private void ShowTwittsInTendency()
    {
        SetCanvasVisibility(tendencyCanvas, false);
        SetCanvasVisibility(twittsInTendecyCanvas, true);
        _twittInTendencyManager.tendency = _tendencyManager.currentTendency;
        _twittInTendencyManager.UpdateTwitts();
        _selectTwitt._tendency = _tendencyManager.currentTendency;
    }

    private void ShowSelectTwitt()
    {
        SetCanvasVisibility(selectTwittCanvas, true);
        _selectTwitt.gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("click");
    }

    private void ShowTwitsInResponse(RickTwittSO currentRickyTwit)
    {
        _twittsInResponseManager.currentTwitt = currentRickyTwit;
        SetCanvasVisibility(selectTwittCanvas, false);
        SetCanvasVisibility(twittsInResponseCanvas, true);
        _twittsInResponseManager.gameObject.SetActive(true);
        _twittsInResponseManager.UpdateTwitts();
        _selectTwitt.gameObject.SetActive(false);
    }

    private void SetCanvasVisibility(CanvasGroup canvas, bool state)
    {
        canvas.alpha = state ? 1 : 0;
        canvas.interactable = state;
        canvas.blocksRaycasts = state;
    }
}