using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOn : MonoBehaviour
{
    private Coroutine GameClock;

    private void Start()
    {
        GameManager.clockGameTime = 0;
        GameManager.isGameStarted = true;
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
