using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform SpawnPoint1;
    public Transform SpawnPoint2;

    public bool isSpawnOnLeft = true;

    public float currentTime;
    public float SpawnTime = 5;

    public GameObject Enemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > SpawnTime)
        {
            currentTime = 0;

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var spawnTransform = isSpawnOnLeft ? SpawnPoint1 : SpawnPoint2;

        isSpawnOnLeft = !isSpawnOnLeft;

        var enemy = Instantiate(Enemy, spawnTransform.position, Quaternion.identity);
        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,15),ForceMode2D.Impulse);
    }
}
