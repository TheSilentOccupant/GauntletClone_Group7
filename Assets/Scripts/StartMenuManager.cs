using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public GameObject buttonStart;
    public Text textStartMenu;
    //public Text textCharacterMenu;

    private int _playerDecisionMade = 0;

    public void Onstart()
    {
        textStartMenu.gameObject.SetActive(false);
        buttonStart.gameObject.SetActive(false);
        //textCharacterMenu.gameObject.SetActive(true);
    }

    public void OnPlayerDecision()
    {
        _playerDecisionMade++;
        if (_playerDecisionMade == GameManager.playerCount)
        {
            SceneManager.LoadScene(1);
        }
    }
}
