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

    private GameObject CurrentBullet;

    Vector3 p0, p1, p2, p01, p12, p012;

    float u;

    float timeStart;
    float timeDuration = 2f;

    private bool BeginArc;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.Find("Player");
        _agent = this.GetComponent<NavMeshAgent>();
        _agent.stoppingDistance = 5f;
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
        }
        if (BeginArc)
        {
            if (attacked)
            {
                u = (Time.time - timeStart) / timeDuration;
                if (u >= 1)
                {
                    u = 1;
                    attacked = false;
                }
                p01 = (1 - u) * p0 + u * p1;
                p12 = (1 - u) * p1 + u * p2;
                p012 = (1 - u) * p01 + u * p12;
                CurrentBullet.transform.position = p012;
            }
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

            //CurrentBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 32f, ForceMode.Impulse);
            p2 = _target.transform.position;
            p1 = _agent.transform.position + new Vector3(1, 5, 0);
            p0 = _agent.transform.position;
            timeStart = Time.time;

            attacked = true;
            BeginArc = true;
            //Invoke(nameof(ResetAttack), attackDelay);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }
}
