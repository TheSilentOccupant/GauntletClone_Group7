using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPotion", menuName = "Potion/Data", order = 52)]
public class UpgradePotionTemplate : ScriptableObject
{
    [SerializeField]
    private string _potionName;
    [SerializeField]
    private PotionTypes _potionType;
    [SerializeField]
    private int _pointUpgrade;
    [SerializeField]
    private Color _primaryColor;
    [SerializeField]
    private Color _secondaryColor;

    public PotionTypes PotionType
    {
        get { return _potionType; }
    }
    public int PointUpgrade
    {
        get { return _pointUpgrade; }
    }
    public Color PrimaryColor
    {
        get { return _primaryColor; }
    }
    public Color SecondaryColor
    {
        get { return _secondaryColor; }
    }
}
