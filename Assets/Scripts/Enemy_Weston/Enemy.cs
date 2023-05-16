using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    private int _health;

    [SerializeField]
    private int _damage;

    private Vector3 _location;

    public int scoreValue;

    protected private GameObject _target;

    protected private NavMeshAgent _agent;

    public int health { get { return _health; } set { value = _health; } }
    public int damage { get { return _damage; } set { value = _damage; } }

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
            Debug.Log("Pursuing player");
            _agent.destination = _target.transform.position;
            if (_target.GetComponent<PlayerData>().isDead)
            {
                _target = null;
            }
        }
        else
        {
            FindPlayer();
        }
    }

    public virtual void TakeDamage(int damage, PlayerData Attacker)
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
        Debug.Log("Looking for player");
        float tempPlayerDistance = 0;
        for (int i = 0; i < GameManager.playerList.Count; i++)
        {
            if (tempPlayerDistance <= Vector3.Distance(this.transform.position, GameManager.playerList[i].transform.position))
            {
                Debug.Log("Set player");
                tempPlayerDistance = Vector3.Distance(this.transform.position, GameManager.playerList[i].transform.position);
                if (!GameManager.playerList[i].GetComponent<PlayerData>().isDead)
                {
                    _target = GameManager.playerList[i];
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player Hit Owie");
            other.gameObject.GetComponent<PlayerData>().OnTakeDamage(damage);
            this.gameObject.SetActive(false);
        }
    }
}
