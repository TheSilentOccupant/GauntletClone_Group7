using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ProfileUIManager : MonoBehaviour
{
    /*
    [SerializeField]
    public GameObject playerProfile;
    */

    public GameObject ClassMenu;

    /*
    public delegate void playerDecidedDelegate();
    public event playerDecidedDelegate playerDecidedEvent;
    */

    //public PlayerTemplate me;

    [SerializeField]
    private Text _playerNumber;
    [SerializeField]
    private Image _playerSprite;
    [SerializeField]
    private Text _characterName;
    [SerializeField]
    private Text _description;
    [SerializeField]
    private Text _health;
    [SerializeField]
    private Text _score;
    [SerializeField]
    private Text _speed;

    /*
    public string PlayerNumber
    {
        set { value = _playerNumber.text; }
        get { return _playerNumber.text; }
    }
    public string CharacterName
    {
        set { value = _characterName.text; }
        get { return _characterName.text; }
    }
    public string Description
    {
        set { value = _description.text; }
        get { return _description.text; }
    }

    public string Health
    {
        set { value = _health.text; }
        get { return _health.text; }
    }

    public string Speed
    {
        set { value = _speed.text; }
        get { return _speed.text; }
    }
    */

    public void Player1Profile(bool isEnabled)
    {
        //playerProfile.SetActive(isEnabled);
    }

    public void PlayerStatsChangedSubscriber(PlayerTemplate me)
    {
        _playerNumber.text = "Player: " + me.PlayerNumber;
        _characterName.text = me.CharacterName;
        _playerSprite.material = me.CharacterSprite;
        PlayerHealthChanged(me);
    }

    public void PlayerHealthChanged(PlayerTemplate me)
    {
        _health.text = "" + me.Health;
    }

    public void PlayerScoreChanged(PlayerTemplate me)
    {
        _score.text = ""+me.PlayerScore;
    }

    public void PlayerClassDecided()
    {
        ClassMenu.SetActive(false);
        GameManager.PlayerClassDecidedSubscriber();
    }
    
}
