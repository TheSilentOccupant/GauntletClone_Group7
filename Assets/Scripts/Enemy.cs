using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    private int _health;

    private Vector3 _location;

    public int scoreValue;

    protected private GameObject _target;

    protected private NavMeshAgent _agent;

    public int health { get { return _health; } set { value = _health; } }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_target != null)
        {
            _agent.destination = _target.transform.position;
        }
        else
        {
            FindPlayer();
        }
    }

    public void TakeDamage(int damage, PlayerData Attacker)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Attacker.OnScoreUp(scoreValue);
            this.gameObject.SetActive(false);
        }
    }

    //Matthew addition
    protected void FindPlayer()
    {
        float tempPlayerDistance = 0;
        for (int i = 0; i < GameManager.playerList.Count; i++)
        {
            if (tempPlayerDistance >= Vector3.Distance(this.transform.position, GameManager.playerList[i].transform.position))
            {
                tempPlayerDistance = Vector3.Distance(this.transform.position, GameManager.playerList[i].transform.position);
                _target = GameManager.playerList[i];
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit Owie");
            //other.gameobject.GetComponent<Player>.TakeDamage();
            this.gameObject.SetActive(false);
        }
    }
}
