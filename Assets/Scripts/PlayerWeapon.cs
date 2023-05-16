using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private PlayerData _myPlayerData;

    [SerializeField]
    private GameObject tempBullet;

    private void Start()
    {
        GameOn.GameStartedEvent += OnGameStartSubscriber;
    }

    private void OnGameStartSubscriber()
    {
        tempBullet = Instantiate(_myPlayerData.playerDataObject.PlayerAttackProjectile,
            GetComponent<Transform>().position,
            GetComponent<Transform>().rotation);
        tempBullet.GetComponent<MeshRenderer>().material.color = _myPlayerData.playerDataObject.PlayerAttackColor;
        tempBullet.SetActive(false);
        tempBullet.GetComponent<BulletData>().playerBulletOwner = _myPlayerData;
    }

    public void OnFire()
    {
        tempBullet.SetActive(true);
        var dir = (this.transform.forward).normalized;
        tempBullet.transform.position = this.transform.position + (dir * .15f);
        tempBullet.GetComponent<Rigidbody>().velocity = dir * (_myPlayerData.playerDataObject.ShotSpeed * GameManager.globalProjectileSpeed);
    }
}
