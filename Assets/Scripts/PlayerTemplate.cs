using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/Data", order = 51)]
public class PlayerTemplate : ScriptableObject
{
    [SerializeField]
    private string _characterName;
    [SerializeField]
    private string _description;
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _armor;
    [SerializeField]
    private int _shotStrengthMin;
    [SerializeField]
    private int _shotStrengthMax;
    [SerializeField]
    private float _shotSpeed;
    [SerializeField]
    private Size _shotSize;
    [SerializeField]
    private int _shotMonsterMin;
    [SerializeField]
    private int _shotMonsterMax;
    [SerializeField]
    private int _shotGeneratorMin;
    [SerializeField]
    private int _shotGeneratorMax;
    [SerializeField]
    private int _shotPotionMonsterMin;
    [SerializeField]
    private int _shotPotionMonsterMax;
    [SerializeField]
    private int _shotPotionGeneratorMin;
    [SerializeField]
    private int _shotPotionGeneratorMax;
    [SerializeField]
    private int _meleeMonsterMin;
    [SerializeField]
    private int _meleeMonsterMax;
    [SerializeField]
    private Chance _meleeGeneratorChance;
    [SerializeField]
    private int _speed;

    public string CharacterName
    {
        get { return _characterName; }
    }
    public string Description
    {
        get { return _description; }
    }

    public int Health
    {
        get { return _health; }
    }

    public int Armor
    {
        get { return _armor; }
    }

    public int ShotStrengthMin
    {
        get { return _shotStrengthMin; }
    }

    public int ShotStrengthMax
    {
        get { return _shotStrengthMax; }
    }

    public float ShotSpeed
    {
        get { return _shotSpeed; }
    }

    public Size ShotSize
    {
        get { return _shotSize; }
    }

    public int ShotMonsterMin
    {
        get { return _shotMonsterMin; }
    }

    public int ShotMonsterMax
    {
        get { return _shotMonsterMax; }
    }

    public int ShotGeneratorMin
    {
        get { return _shotGeneratorMin; }
    }

    public int ShotGeneratorMax
    {
        get { return _shotGeneratorMax; }
    }

    public int ShotPotionMonsterMax
    {
        get { return _shotPotionMonsterMax; }
    }

    public int ShotPotionMonsterMin
    {
        get { return _shotPotionMonsterMin; }
    }

    public int ShotPotionGeneratorMin
    {
        get { return _shotPotionGeneratorMin; }
    }

    public int ShotPotionGeneratorMax
    {
        get { return _shotPotionGeneratorMax; }
    }

    public int MeleeMonsterMin
    {
        get { return _meleeMonsterMin; }
    }

    public int MeleeMonsterMax
    {
        get { return _meleeMonsterMax; }
    }

    public Chance MeleeGeneratorChance
    {
        get { return _meleeGeneratorChance; }
    }

    public int Speed
    {
        get { return _speed; }
    }
}
