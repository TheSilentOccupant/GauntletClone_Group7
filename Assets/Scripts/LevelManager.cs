using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<GameManager>
{
    public static int currentScene;

    private void Awake()
    {
        base.Awake();
        currentScene = 0;
    }

    public static void NextLevel()
    {
        SceneManager.LoadScene(currentScene++);
    }
}
