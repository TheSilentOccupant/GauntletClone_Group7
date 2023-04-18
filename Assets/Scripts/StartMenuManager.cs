using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public GameObject buttonStart;
    public GameObject mainCamera;

    public Text textStartMenu;
    //public Text textCharacterMenu;


    public void Onstart()
    {
        textStartMenu.gameObject.SetActive(false);
        buttonStart.gameObject.SetActive(false);
        //textCharacterMenu.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (GameManager.playerReadyCount > 0)
        {
            if (GameManager.playerReadyCount == GameManager.playerCount)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    public void PlayerJoined(PlayerInput newPlayer)
    {
        mainCamera.SetActive(false);
    }
}
