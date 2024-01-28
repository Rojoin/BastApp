using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Member : MonoBehaviour
{
    public void openUrl(string url)
    {
        Application.OpenURL(url);
    }
}
