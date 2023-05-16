using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WizardEnemy : Enemy
{
    private float attackDelay = 1f;
    private float attackRange = 6;

    public LayerMask PlayerLayer;

    public bool PlayerInRange;
    public bool attacked;
    [SerializeField]
    private GameObject LobberBullet;

    private GameObject CurrentBullet;

    private float alphaLevel;

    private float timeStart;
    private float timeDuration = 2f;
    [SerializeField]
    private bool blinking;

    private float blinkDelay = 5f;

    private bool Damageable;

    protected override void Update()
    {
        PlayerInRange = Physics.CheckSphere(transform.position, attackRange, PlayerLayer);

        if (!PlayerInRange)
        {
            _agent.destination = _target.transform.position;
            if (blinking == false)
            {
                Blink();
            }
        }
        else if (PlayerInRange && !attacked)
        {
            AttackPlayer();
            _agent.destination = _target.transform.position;
        }
        Color existingcolor = gameObject.GetComponent<Renderer>().material.color;
        if (blinking)
        {
            alphaLevel = (Time.time - timeStart) / timeDuration;
            if (alphaLevel >= 1)
            {
                //blinking = false;
                alphaLevel = 1;
            }
        }

        gameObject.GetComponent<Renderer>().material.color = new Color(existingcolor.r, existingcolor.g, existingcolor.b, alphaLevel);
        Debug.Log(GetComponent <Renderer>().material.color);
    }

    public override void TakeDamage(int damage, PlayerData Attacker)
    {
        if (Damageable)
        {
            health -= damage;
            if (health <= 0)
            {
                Attacker.OnScoreUp(scoreValue);
                this.gameObject.SetActive(false);
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
            //transform.LookAt(_player.transform);
            CurrentBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 32f, ForceMode.Impulse);


            attacked = true;

            Invoke(nameof(ResetAttack), attackDelay);
        }
    }

    private void Blink()
    {
        blinking = true;
        timeStart = Time.time;
        alphaLevel = 0;
        Invoke(nameof(ResetBlink), blinkDelay);
    }

    private void ResetAttack()
    {
        attacked = false;
    }

    private void ResetBlink()
    {
        blinking = false;
    }
}
