using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetSpawnPosition : MonoBehaviour
{
    [SerializeField]
    private int _playerIDNumber;

    void Start()
    {
        if(_playerIDNumber < GameManager.playerList.Count)
            GameManager.playerList[_playerIDNumber].gameObject.transform.position = this.gameObject.transform.position;
    }
}
