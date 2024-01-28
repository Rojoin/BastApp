using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public void changeScene(string scene)
    {
        FindAnyObjectByType<AudioManager>().Play("click");
        FindAnyObjectByType<LevelManager>().changeScene(scene);
    }

    public void changeTheme(string theme)
    {
        AudioManager.instance.StopCurrentTheme();
        AudioManager.instance.PlayTheme(theme);
    }
}
