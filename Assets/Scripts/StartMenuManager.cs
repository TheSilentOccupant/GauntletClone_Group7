using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public Button buttonStart;
    public Button buttonUp;
    public Button buttonDown;
    public Button buttonLeft;
    public Button buttonRight;
    public Button buttonMiddle;
    public Text textStartMenu;
    public Text textCharacterMenu;


    private void Start()
    {
        buttonUp.gameObject.SetActive(false);
        buttonDown.gameObject.SetActive(false);
        buttonLeft.gameObject.SetActive(false);
        buttonRight.gameObject.SetActive(false);
        buttonMiddle.gameObject.SetActive(false);
    }


    public void Onstart()
    {
        textStartMenu.gameObject.SetActive(false);
        buttonStart.gameObject.SetActive(false);
        //textCharacterMenu.gameObject.SetActive(true);

        buttonMiddle.Select();

        buttonUp.gameObject.SetActive(true);
        buttonDown.gameObject.SetActive(true);
        buttonLeft.gameObject.SetActive(true);
        buttonRight.gameObject.SetActive(true);
        buttonMiddle.gameObject.SetActive(true);
    }

}
