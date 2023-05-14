using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private PlayerData _myPlayerData;

    public void OnFire()
    {
        GameObject tempBullet;
        tempBullet = Instantiate(_myPlayerData.playerDataObject.PlayerAttackProjectile,
            GetComponent<Transform>().position,
            GetComponent<Transform>().rotation);
        tempBullet.GetComponent<MeshRenderer>().material.color = _myPlayerData.playerDataObject.PlayerAttackColor;

        var dir = (this.transform.forward).normalized;
        tempBullet.transform.position = tempBullet.transform.position + (dir * .35f);
        Debug.Log(tempBullet.transform.position);
        tempBullet.GetComponent<Rigidbody>().velocity = dir * (_myPlayerData.playerDataObject.ShotSpeed * GameManager.globalProjectileSpeed);
    }
}
