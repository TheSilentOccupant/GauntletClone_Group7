using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public delegate void playerLowHealthDelegate(ClassType classHolder);
    public event playerLowHealthDelegate playerLowHealthEvent;
    
    public PlayerTemplate playerDataObject;

    public Text storyText;

    [SerializeField]
    private ProfileUIManager _myProfileUIManager;

    public Camera playerCamera;

    [SerializeField]
    private PlayerAvatarController _myPlayerAvatarController;

    public bool playerReady;
    public bool isTouchingDeath;

    bool isWarned1, isWarned2, isWarned3, isWarned4;

    private void Start()
    {
        playerReady = false;
    }

    public void OnDataUpdate(PlayerTemplate classHolder)
    {
        Debug.Log("Stat Change");
        playerDataObject = classHolder;
        playerDataObject.PlayerNumber = this.gameObject.GetComponent<PlayerController>().playerIndexNumber + 1;
        Debug.Log(playerDataObject.PlayerNumber);
        _myProfileUIManager.PlayerStatsChangedSubscriber(playerDataObject);
        _myPlayerAvatarController.ClassChange(playerDataObject);
    }

    public void OnPlayerClassDecided()
    {
        playerDataObject = Instantiate(playerDataObject);
        playerDataObject.PlayerNumber = this.gameObject.GetComponent<PlayerController>().playerIndexNumber + 1;
        _myProfileUIManager.PlayerStatsChangedSubscriber(playerDataObject);
        _myPlayerAvatarController.ClassChange(playerDataObject);
        _myProfileUIManager.PlayerHealthChanged(playerDataObject);
        _myProfileUIManager.PlayerScoreChanged(playerDataObject);
    }

    public void OnTakeDamage(int damage)
    {
        playerDataObject.Health -= damage;
        if (playerDataObject.Health == 200 && !isWarned1)
        {
            isWarned1 = true;
            playerLowHealthEvent(playerDataObject.CharacterName);
        }
        _myProfileUIManager.PlayerHealthChanged(playerDataObject);
    }
    public void OnHeal(int heal)
    {
        playerDataObject.Health += heal;
        if (playerDataObject.Health >= 200)
        {
            isWarned1 = true;
            playerLowHealthEvent(playerDataObject.CharacterName);
        }
        _myProfileUIManager.PlayerHealthChanged(playerDataObject);
    }
    public void OnScoreUp(int score)
    {
        playerDataObject.PlayerScore += score;
        _myProfileUIManager.PlayerScoreChanged(playerDataObject);
    }
}
