using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private int Health;

    private Vector3 location;

    private GameObject Player;

    private NavMeshAgent Agent;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Agent.destination = Player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit Owie");
        }
    }
}
