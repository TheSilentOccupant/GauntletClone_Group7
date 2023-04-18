using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private int _health;

    private Vector3 _location;

    protected private GameObject _player;

    protected private NavMeshAgent _agent;

    public int health { get { return _health; } set { value = _health; } }

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        _agent.destination = _player.transform.position;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
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
