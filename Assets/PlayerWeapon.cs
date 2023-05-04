using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private PlayerData _myPlayerData;

    public void OnFire()
    {
        GameObject tempBullet;
        tempBullet = Instantiate(_myPlayerData.playerDataObject.PlayerAttackProjectile,
            GetComponent<Transform>().position,
            GetComponent<Transform>().rotation);

        var dir = (this.transform.up).normalized;
        tempBullet.transform.position = tempBullet.transform.position + (dir * 1.05f);
        Debug.Log(tempBullet.transform.position);
        tempBullet.GetComponent<Rigidbody>().velocity = dir * (_myPlayerData.playerDataObject.ShotSpeed);
    }
}
