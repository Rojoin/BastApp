using System;
using UnityEngine;
using UnityEngine.Serialization;


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

    private RickTwittSO currentTwitt = null;
    private void Awake()
    {
        SetCanvasVisibility(tendencyCanvas, true);
        SetCanvasVisibility(twittsInTendecyCanvas, false);
        SetCanvasVisibility(selectTwittCanvas, false);
        SetCanvasVisibility(twittsInResponseCanvas, false);
        SetCanvasVisibility(resultsScreenCanvas, false);
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
    }
    private void ShowTwitsInResponse()
    {
        //use event to select currentTwitt
        SetCanvasVisibility(selectTwittCanvas, false);
        SetCanvasVisibility(twittsInResponseCanvas, true);
        
    }

    private void SetCanvasVisibility(CanvasGroup canvas, bool state)
    {
        canvas.alpha = state ? 1 : 0;
        canvas.interactable = state;
        canvas.blocksRaycasts = state;
    }
}