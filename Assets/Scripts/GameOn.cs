using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOn : Singleton<GameOn>
{
    private Coroutine GameClock;

    public delegate void GameStartedDelegate();
    public static event GameStartedDelegate GameStartedEvent;

    public override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        GameManager.clockGameTime = 0;
        GameManager.isGameStarted = true;
        GameStartedEvent();
        GameClock = StartCoroutine(Clock());
    }

    public IEnumerator Clock()
    {
        while (GameManager.isGameStarted)
        {
            if (!GameManager.isGamePaused)
            {
                GameManager.clockGameTime++;

                for (int i = 0; i < GameManager.playerList.Count; i++)
                {
                    GameManager.playerList[i].GetComponent<PlayerData>().OnTakeDamage(1);
                }

                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
