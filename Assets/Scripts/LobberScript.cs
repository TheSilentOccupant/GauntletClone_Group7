using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LobberScript : Enemy
{
    private float attackDelay = 1f;
    private float attackRange = 6;

    public LayerMask PlayerLayer;

    public bool PlayerInRange;
    public bool attacked;
    [SerializeField]
    private GameObject LobberBullet;

    private GameObject CurrentBullet;

    private void Start()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _target = GameObject.Find("Player");
    }

    // Update is called once per frame
    protected override void Update()
    {
        PlayerInRange = Physics.CheckSphere(transform.position, attackRange, PlayerLayer);

        if (!PlayerInRange)
        {
            _agent.destination = _target.transform.position;
        }
        else if (PlayerInRange && !attacked)
        {
            AttackPlayer();
            _agent.destination = _target.transform.position;
        }
        

    }

    private void AttackPlayer()
    {
        _agent.SetDestination(transform.position);
        transform.LookAt(_target.transform);

        if (!attacked)
        {
            //sents bullet at player
            //Debug.Log("Attacking Player");
            CurrentBullet = Instantiate(LobberBullet, gameObject.transform.position, gameObject.transform.rotation);
            //transform.LookAt(_player.transform);
            CurrentBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 32f, ForceMode.Impulse);
            

            attacked = true;
           
            Invoke(nameof(ResetAttack), attackDelay);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }

}
