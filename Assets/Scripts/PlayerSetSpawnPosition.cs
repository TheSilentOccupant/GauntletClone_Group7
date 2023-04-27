using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetSpawnPosition : MonoBehaviour
{
    [SerializeField]
    private int _playerIDNumber;

    void Start()
    {
        Debug.Log("Spawning Player");
        if(_playerIDNumber <= GameManager.playerList.Count)
            GameManager.playerList[_playerIDNumber-1].gameObject.transform.position = this.gameObject.transform.position;
    }
}
