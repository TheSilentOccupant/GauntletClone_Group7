using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThiefScript : Enemy
{
    private float attackDelay = 1f;
    private float attackRange = 3;

    public LayerMask PlayerLayer;

    public bool PlayerInRange;
    public bool attacked;
    [SerializeField]
    private GameObject LobberBullet;

    private GameObject CurrentBullet;

    //private string StolenItem
    /*
    private void Start()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player");
    }
    */
    // Update is called once per frame
    protected override void Update()
    {
        PlayerInRange = Physics.CheckSphere(transform.position, attackRange, PlayerLayer);

        if (!PlayerInRange && !attacked)
        {
            _agent.destination = _target.transform.position;
        }
        else if (PlayerInRange && !attacked)
        {
            AttackPlayer();
            _agent.destination = _target.transform.position;
        }
        else if (PlayerInRange && attacked)
        {
            _agent.destination = -_target.transform.position;
        }

        if (health <= 0)
        {
            GiveItemBack();
        }

    }

    private void AttackPlayer()
    {
        _agent.SetDestination(transform.position);
        transform.LookAt(_target.transform);

        if (!attacked)
        {
            //Steal(_player.GetComponent<Inventory?>());
            attacked = true;
        }
    }

    //private void Steal(Inventory Player)
    //{
         //StolenItem = Player.Item;
         //Player.LoseItem();
    //}

    private void GiveItemBack()
    {

    }

    
}
