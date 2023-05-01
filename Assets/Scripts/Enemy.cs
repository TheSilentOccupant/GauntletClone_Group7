using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private int _health;

    private Vector3 _location;

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
        FindPlayer();
        if(_target != null)
            _agent.destination = _target.transform.position;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

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
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(5);
        }
    }
}
