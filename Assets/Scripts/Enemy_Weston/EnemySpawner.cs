using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [Header("Enemy Typing")]
    [SerializeField]
    private GameObject Enemy1;//ghost prefab
    [SerializeField]
    private GameObject Enemy2;//Lobber prefab
    [SerializeField]
    private GameObject Enemy3;//Goblin Prefab
    public enum EnemyType { Ghost,Lobber,Goblin};
    public EnemyType EnemySpawned;
    [Range(1, 3)]
    [SerializeField]
    private int SpawnerLevel = 1;
    private GameObject SpawnerEnemy;

    public List<GameObject> EnemyPool;
    [SerializeField]
    private int amountToPool;
    Vector3 spawnlocation;
    Quaternion spawnrotation;

    // Start is called before the first frame update
    void Start()
    {
        spawnlocation = transform.position + new Vector3(1f, 0f, 0f);
        spawnrotation = transform.rotation;
        switch (EnemySpawned)
        {
            case 0:
                SpawnerEnemy = Enemy1;
                break;
            case EnemyType.Lobber:
                SpawnerEnemy = Enemy2;
                break;
            case EnemyType.Goblin:
                SpawnerEnemy = Enemy3;
                break;
            default:
                SpawnerEnemy = Enemy1;
                break;
        }
        

        EnemyPool = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject Enemy = (GameObject.Instantiate(SpawnerEnemy));
            Enemy.SetActive(false);
            EnemyPool.Add(Enemy);
        }

        InvokeRepeating("SpawnEnemies", 5f, 1f);

    }

    IEnumerator SpawnEnemies()
    {
       switch (SpawnerLevel)
       {
            case 1:
                Spawn1Enemy();
                break;
            case 2:
                Spawn1Enemy();
                Spawn1Enemy();
                break;
            case 3:
                Spawn1Enemy();
                Spawn1Enemy();
                Spawn1Enemy();
                break;
            default:
                break;
       }
        return null;
    }
    public void Spawn1Enemy()
    {
        GameObject CurrentSpawning = GetEnemy();
        if (CurrentSpawning != null)
        {
            CurrentSpawning.transform.position = spawnlocation;
            CurrentSpawning.transform.rotation = spawnrotation;
            CurrentSpawning.GetComponent<Enemy>().health = (SpawnerLevel * 10);
            CurrentSpawning.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetEnemy()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!EnemyPool[i].activeInHierarchy)
            {
                return EnemyPool[i];
            }
        }
        return null;
    }
}
