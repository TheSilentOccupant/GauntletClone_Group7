using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : Enemy
{
    private GameObject touchedPlayer;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(DeathTouch());
    }

    public IEnumerator DeathTouch()
    {
        while (true)
        {
            if (touchedPlayer != null)
                touchedPlayer.GetComponent<PlayerData>().OnTakeDamage(1);
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            touchedPlayer = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            touchedPlayer = null;
    }
}
