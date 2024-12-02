using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Asteroid Movement")]
    public float moveSpeed;
    private Rigidbody enemyRb;
    private GameObject player;

    [Header("Spliter Variables")]
    public GameObject smallerEnemy;
    public int smallerEnemyToSpawn;

    [Header("Score")]
    public int pointValue;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gm.AddScore(pointValue);
            Destroy(collision.gameObject);
            SpawnSmaller(smallerEnemyToSpawn);
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void SpawnSmaller(int numberToSpawn)
    {
        if(smallerEnemy != null)
        {
            for(int i = 0; i < numberToSpawn; i++)
            {
                Instantiate(smallerEnemy, transform.position, transform.rotation);
            }
            
        }
    }
}
