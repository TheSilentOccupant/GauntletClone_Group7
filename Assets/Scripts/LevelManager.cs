using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public static int currentScene;

    public override void Awake()
    {
        base.Awake();
        currentScene = 1;
    }

    public static void NextLevelMenuButton()
    {
        SceneManager.LoadScene(1);
    }

    public static void NextLevel()
    {
        SceneManager.LoadScene(currentScene++);
    }
}
