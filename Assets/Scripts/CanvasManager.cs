﻿using System;
using DefaultNamespace;
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
    [SerializeField] private ResultScreen resultScreen;
    [SerializeField] private GameManager gameManager;
    [Header("Canvas")]
    [SerializeField] private CanvasGroup tendencyCanvas;
    [SerializeField] private CanvasGroup twittsInTendecyCanvas;
    [SerializeField] private CanvasGroup selectTwittCanvas;
    [SerializeField] private CanvasGroup twittsInResponseCanvas;
    [SerializeField] private CanvasGroup resultsScreenCanvas;
    [Header("Buttons")]
    [SerializeField] private Button openResponseButton;
    [SerializeField] private Button openResultsButton;

    private RickTwittSO currentTwitt = null;

    private void Awake()
    {
        SetCanvasVisibility(tendencyCanvas, true);
        SetCanvasVisibility(twittsInTendecyCanvas, false);
        SetCanvasVisibility(selectTwittCanvas, false);
        SetCanvasVisibility(twittsInResponseCanvas, false);
        SetCanvasVisibility(resultsScreenCanvas, false);
        _tendencyManager.chooseTendency.AddListener(ShowTwittsInTendency);
        _tendencyManager.activateEnding.AddListener(ActivateEnding);
        openResponseButton.onClick.AddListener(ShowSelectTwitt);
        _selectTwitt.onTwittChoosed.AddListener(ShowTwitsInResponse);
        openResultsButton.onClick.AddListener(ShowResults);
        resultScreen.onResultScreenEnd.AddListener(ShowTendencies);
    }


    private void OnDisable()
    {
        _tendencyManager.activateEnding.RemoveListener(ActivateEnding);
        _tendencyManager.chooseTendency.RemoveListener(ShowTwittsInTendency);
        openResponseButton.onClick.RemoveListener(ShowSelectTwitt);
        _selectTwitt.onTwittChoosed.RemoveListener(ShowTwitsInResponse);
        openResultsButton.onClick.RemoveListener(ShowResults);
        resultScreen.onResultScreenEnd.RemoveListener(ShowTendencies);
    }
    private void ActivateEnding()
    {
        gameManager.GetEnding();
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
        _selectTwitt.Init();
        FindObjectOfType<AudioManager>().Play("click");
    }

    private void ShowTwitsInResponse(RickTwittSO currentRickyTwit)
    {
        _selectTwitt.Disable();
        _twittsInResponseManager.currentTwitt = currentRickyTwit;
        SetCanvasVisibility(twittsInTendecyCanvas, false);
        SetCanvasVisibility(selectTwittCanvas, false);
        SetCanvasVisibility(twittsInResponseCanvas, true);
        _twittsInResponseManager.gameObject.SetActive(true);
        _twittsInResponseManager.UpdateTwitts();
    }

    private void ShowResults()
    {
        SetCanvasVisibility(resultsScreenCanvas,true);
        SetCanvasVisibility(twittsInResponseCanvas,false);
        SetCanvasVisibility(tendencyCanvas,true);
        resultScreen.currentTwitt = _twittsInResponseManager.currentTwitt;
        resultScreen.currentTendency = _tendencyManager.currentTendency;
        resultScreen.SetFollowersRep(gameManager.currentSubs,gameManager.currentRep,gameManager.maxSubs);
        resultScreen.StartStats();
    }

    private void ShowTendencies()
    {
        SetCanvasVisibility(resultsScreenCanvas,false);
        _tendencyManager.Init();
    }

    private void SetCanvasVisibility(CanvasGroup canvas, bool state)
    {
        canvas.alpha = state ? 1 : 0;
        canvas.interactable = state;
        canvas.blocksRaycasts = state;
    }
}