using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void changeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
