using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static int playerCount;

    public static int playerReadyCount;

    public static float clockGameTime = 0;

    public static bool isGameStarted;

    public static bool isGamePaused = false;

    public static int globalProjectileSpeed = 1;

    private int _controllersConnected;

    PlayerInputManager playerInputManager;

    public bool isPlayerjoiningAllowed;
    public bool isPlayerReady;
    

    public static List<GameObject> playerList;


    public override void Awake()
    {
        base.Awake();

        isPlayerjoiningAllowed = false;
        playerInputManager = GetComponent<PlayerInputManager>();
        playerInputManager.DisableJoining();
        InputSystem.onDeviceChange +=
        (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    CheckControllerCount();
                    break;

                case InputDeviceChange.Removed:
                    CheckControllerCount();
                    break;
            }
        };
        playerList = new List<GameObject>();
    }

    private void Update()
    {

    }

    public void GameStart()
    {
        isPlayerjoiningAllowed = true;
        playerInputManager.EnableJoining();
        CheckControllerCount();
    }

    public void CheckControllerCount()
    {
        int numberOfGamepads = 0;
        foreach (InputDevice id in InputSystem.devices)
        {
            if (id.layout.Contains("Dual"))
            {
                numberOfGamepads++;
            }
            else if (id.layout.Contains("Joystick"))
            {
                numberOfGamepads++;
            }
            else if (id.layout.Contains("Gamepad"))
            {
                numberOfGamepads++;
            }
            else if (id.layout.Contains("Xbox"))
            {
                numberOfGamepads++;
            }
        }
    }

    public static void PlayerClassDecidedSubscriber()
    {
        playerReadyCount++;
        if (playerCount == playerReadyCount)
        {
            GameManager.Instance.playerInputManager.DisableJoining();
            LevelManager.NextLevel();
        }
    }

    public void PlayerConnected(PlayerInput newPlayer)
    {
        playerCount++;
        //Debug.Log(newPlayer.playerIndex);
        playerList.Add(newPlayer.gameObject);
    }
}
