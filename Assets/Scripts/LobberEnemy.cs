using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LobberEnemy : Enemy
{
    private float attackDelay = 1f;
    private float attackRange=6;

    public LayerMask PlayerLayer;

    public bool PlayerInRange;
    public bool attacked;
    [SerializeField]
    private GameObject LobberBullet; 


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _agent = this.GetComponent<NavMeshAgent>();
        _agent.stoppingDistance = 5f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        PlayerInRange = Physics.CheckSphere(transform.position, attackRange, PlayerLayer);

        if (!PlayerInRange)
        {
            _agent.destination = _player.transform.position;
        }
        else
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        _agent.SetDestination(transform.position);
        transform.LookAt(_player.transform);

        if (!attacked)
        {
            //sents bullet at player
            Debug.Log("Attacking Player");
            GameObject CurrentBullet = Instantiate(LobberBullet, this.gameObject.transform.position, this.gameObject.transform.rotation);

            CurrentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);

            attacked = true;
            Invoke(nameof(ResetAttack), attackDelay);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }
}
