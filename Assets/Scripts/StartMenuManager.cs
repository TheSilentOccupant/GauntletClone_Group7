using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public GameObject buttonStart;
    public GameObject mainCamera;

    public Text textStartMenu;
    public GameObject textConnectpromt;


    public void Onstart()
    {
        textStartMenu.gameObject.SetActive(false);
        buttonStart.gameObject.SetActive(false);
        textStartMenu.gameObject.SetActive(true);
        textConnectpromt.gameObject.SetActive(true);
    }


    public void PlayerJoined(PlayerInput newPlayer)
    {
        textConnectpromt.gameObject.SetActive(false);
        textStartMenu.gameObject.SetActive(false);
        mainCamera.SetActive(false);
        //buttonStart.GetComponent<MultiplayerEventSystem>().SetSelectedGameObject(null);
    }
}
