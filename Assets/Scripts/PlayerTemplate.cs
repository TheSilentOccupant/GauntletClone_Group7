using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/Data", order = 51)]
public class PlayerTemplate : ScriptableObject
{
    [SerializeField]
    private int _playerNumber;
    [SerializeField]
    private Material _sprite;
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
    [SerializeField]
    private Color _playerBodyColor;
    [SerializeField]
    private Color _playerHeadColor;
    [SerializeField]
    private Color _playerAttackColor;
    [SerializeField]
    private GameObject _playerAttackProjectile;

    public int PlayerNumber
    {
        set { _playerNumber = value; }
        get { return _playerNumber; }
    }

    public Material CharacterSprite
    {
        get { return _sprite; }
    }

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
        set { _health = value; }
        get { return _health; }
    }

    public int Armor
    {
        set { _armor = value; }
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
        set { _speed = value; }
        get { return _speed; }
    }

    public Color PlayerBodyColor
    {
        get { return _playerBodyColor; }
    }

    public Color PlayerHeadColor
    {
        get { return _playerHeadColor; }
    }

    public Color PlayerAttackColor
    {
        get { return _playerAttackColor; }
    }

    public GameObject PlayerAttackProjectile
    {
        get { return _playerAttackProjectile; }
    }
}
