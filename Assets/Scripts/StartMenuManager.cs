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


    public void Onstart()
    {
        textStartMenu.gameObject.SetActive(false);
        buttonStart.gameObject.SetActive(false);
    }


    public void PlayerJoined(PlayerInput newPlayer)
    {
        mainCamera.SetActive(false);
    }
}
