using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpUpgradePotion : MonoBehaviour
{
    public UpgradePotionType potion;

    public int potionValue;

    [SerializeField]
    private Color PrimaryColor;
    [SerializeField]
    private Color SecondaryColor;
    [SerializeField]
    private GameObject primaryObject;
    [SerializeField]
    private GameObject secondaryObject;


    private void Start()
    {
        primaryObject.GetComponent<MeshRenderer>().material.color = PrimaryColor;
        secondaryObject.GetComponent<MeshRenderer>().material.color = SecondaryColor;
    }
}
