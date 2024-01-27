using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Endings
{
    GOOD_ENDING = 0,
    BAD_ENDING,
    LOST
}

public class GameManager : MonoBehaviour
{
    public int maxSubs = 100;
    public int repThreshold = 50;
    private int currentSubs = 0;
    private int currentRep = 50; // Initialize currentRep to 50
    private bool lost = false;

    void Start()
    {
        //// End game logic
        //EvaluateEndGame();

        //// Print information to the console
        //PrintInformation();
    }

    Endings GetEnding()
    {
        if (IsGoodEnding())
        {
            return Endings.GOOD_ENDING;
        }
        else if (IsBadEnding())
        {
            return Endings.BAD_ENDING;
        }
        else if (Lost())
        {
            return Endings.LOST;
        }
        return Endings.LOST;
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
