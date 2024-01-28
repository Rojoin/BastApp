using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Endings
{
    MIAMI_ENDING = 0,
    COMANDANTE_ENDING,
    LOST
}

public class GameManager : MonoBehaviour
{
    public int maxSubs = 100;
    public int repThreshold = 50;
    public int currentSubs = 0;
    public int currentRep = 50; // Initialize currentRep to 50
    private bool lost = false;
    public EndingSelector endingSelector;
    public List<Tendency> tendencies;
    void Start()
    {
        //// End game logic
        //EvaluateEndGame();

        //// Print information to the console
        //PrintInformation();
    }

    private void OnDisable()
    {
        foreach (var tendency in tendencies)
        {
            tendency.hasBeenTwitted = false;
        }
    }

    public void GetEnding()
    {
        if (IsGoodEnding())
        {
            endingSelector.ending = Endings.MIAMI_ENDING;
        }
        else if (IsBadEnding())
        {
            endingSelector.ending = Endings.COMANDANTE_ENDING;
        }
        else if (Lost())
        {
            endingSelector.ending = Endings.LOST;
        }

        endingSelector.ending = Endings.LOST;
    }

    void PrintInformation()
    {
        UnityEngine.Debug.Log("Max Subs: " + maxSubs);
        UnityEngine.Debug.Log("Subs: " + currentSubs);
        UnityEngine.Debug.Log("Rep: " + currentRep);
    }

    // Methods to obtain values (simulated)
    int GetMaxSubs() => maxSubs;
    int GetCurrentSubs() => currentSubs; // Set to a value below maxSubs for demonstration purposes
    int GetCurrentRep() => currentRep; // Set to a value above repThreshold for demonstration purposes

    // Methods to evaluate end game
    bool IsGoodEnding() => currentSubs >= maxSubs && currentRep >= repThreshold;
    bool IsBadEnding() => currentSubs >= maxSubs && currentRep < repThreshold;
    bool Lost() => currentSubs < maxSubs;
}