using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public int BulletDamage = 0;

    private float _distance_To_Wall_Front = 2f;

    public PlayerData playerBulletOwner;

    private void Update()
    {
        DistanceToWall();
    }

    private void DistanceToWall()
    {
        RaycastHit hit;
        Ray front_Ray = new Ray(transform.position, this.transform.forward);

        if (Physics.Raycast(front_Ray, out hit))
        {
            _distance_To_Wall_Front = hit.distance;
            if (hit.distance <= .1f)
            {
                if (hit.transform.gameObject.tag == "Wall")
                {
                    this.gameObject.SetActive(false);
                }
                if (hit.transform.gameObject.tag == "Door")
                {
                    this.gameObject.SetActive(false);
                }
                if (hit.transform.gameObject.tag == "Food")
                {
                    StoryTeller.ShotFoodSubscriber(playerBulletOwner.playerDataObject.CharacterName);
                    hit.transform.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (hit.transform.gameObject.tag == "RegPotion")
                {
                    hit.transform.gameObject.GetComponent<RegularPotion>().OnInteraction(playerBulletOwner);
                    this.gameObject.SetActive(false);
                }
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(BulletDamage, playerBulletOwner);
                    this.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            _distance_To_Wall_Front = 3;
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall" || other.tag == "Door")
        {
            this.gameObject.SetActive(false);
        }
    }
    */
}
