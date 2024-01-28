using System;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Create RickTwittSO", fileName = "RickTwittSO", order = 1)]
public class RickTwittSO : TwittSO
{
    [Header("Option prompt")]
    public string optionPrompt;

    [Header("Possible responses to Ricky")]
    public List<TwittSO> posibleTwitts;
}
