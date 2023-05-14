using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPotion", menuName = "Potion/Data", order = 52)]
public class UpgradePotionTemplate : ScriptableObject
{
    [SerializeField]
    private string _potionName;
    [SerializeField]
    private UpgradePotionType _potionType;
    [SerializeField]
    private Color _primaryColor;
    [SerializeField]
    private Color _secondaryColor;

    public UpgradePotionType PotionType
    {
        get { return _potionType; }
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
