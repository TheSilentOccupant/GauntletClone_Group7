using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOn : MonoBehaviour
{
    private void Start()
    {
        GameManager.clockGameTime = 0;
        GameManager.isGameStarted = true;
    }
}
