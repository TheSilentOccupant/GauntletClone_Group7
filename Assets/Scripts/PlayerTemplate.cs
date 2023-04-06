using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Data", order = 51)]
public class PlayerTemplate : ScriptableObject
{
    [SerializeField]
    private string _characterName;
    [SerializeField]
    private string _description;
    [SerializeField]
    private int goldCost;
    [SerializeField]
    private int attackDamage;

    public string CharacterName
    {
        get { return _characterName; }
    }
    public string Description
    {
        get { return _description; }
    }

    public int GoldCost
    {
        get { return goldCost; }
    }

    public int AttackDamage
    {
        get { return attackDamage; }
    }
}
