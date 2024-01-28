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

    public List<Tendency> allTendencies;

    
    void Start()
    {
        //// End game logic
        //EvaluateEndGame();

        //// Print information to the console
        //PrintInformation();
        foreach (var tendency in allTendencies)
        {
            tendency.hasBeenTwitted = false;
            foreach (var twitt in tendency.relatedTweets)
            {
               twitt.Reset(); 
            }

            foreach (var rickTwittSo in tendency.possibleResponses)
            {
                foreach (var respondTwitt in rickTwittSo.posibleTwitts)
                {
                    respondTwitt.Reset();
                }
            }
        }

      
    }

    private void OnDisable()
    {
        foreach (var tendency in allTendencies)
        {
            tendency.hasBeenTwitted = false;
            foreach (var twitt in tendency.relatedTweets)
            {
                twitt.Reset(); 
            }

            foreach (var rickTwittSo in tendency.possibleResponses)
            {
                foreach (var respondTwitt in rickTwittSo.posibleTwitts)
                {
                    respondTwitt.Reset();
                }
            }
        }
    }

    public void GetEnding()
    {
        AudioManager.instance.StopCurrentTheme();
        Debug.Log("END SUBS: " + currentSubs + ", END REP: " + currentRep);
        if (IsGoodEnding())
        {
            AudioManager.instance.PlayTheme("GoodEnding");
            endingSelector.ending = Endings.MIAMI_ENDING;
        }
        else if (IsBadEnding())
        {
            AudioManager.instance.PlayTheme("CommanderEnding");
            endingSelector.ending = Endings.COMANDANTE_ENDING;
        }
        else if (Lost())
        {
            AudioManager.instance.PlayTheme("SkyEnding");
            endingSelector.ending = Endings.LOST;
        }

        endingSelector.ending = Endings.LOST;
        LevelManager.Instance.changeScene("Ending");
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