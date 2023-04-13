using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private int _playerCount;
    private int _controllersConnected;

    PlayerInputManager playerInputManager;

    public bool isPlayerjoiningAllowed;
    public bool isPlayerReady;

    public delegate void playerLostDelegate();
    public event playerLostDelegate playerLostEvent;


    private void Awake()
    {
        isPlayerjoiningAllowed = false;
        playerInputManager = GetComponent<PlayerInputManager>();
        playerInputManager.DisableJoining();
    }

    
    private void Update()
    {
        Debug.Log(Input.GetJoystickNames().Length);
        //InputAction.CallbackContext contex;

        if (isPlayerjoiningAllowed)
        {
            playerInputManager.EnableJoining();
            _controllersConnected = Input.GetJoystickNames().Length;
            if (_playerCount != _controllersConnected)
            {
                //playerInputManager.JoinPlayerFromActionIfNotAlreadyJoined();
            }
        }
        
    }
    

    public void PlayerConnected()
    {
        _playerCount++;
    }
}
