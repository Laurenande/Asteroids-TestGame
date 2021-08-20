using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    [SerializeField]
    private ObjectPooler.ObjectInfo.ObjectType bulletType;
    private Vector3 spawnPosition;
    public float xSpawnPos;
    public float ySpawnPos;
    private int countAsteroids;
    void Start()
    {
        countAsteroids = 3;
        AsteroidsSpawn();
    }

    private void AsteroidsSpawn()
    {
        for (int i = 0; i < countAsteroids; i++)
        {
            spawnPosition = new Vector3(Random.Range(-xSpawnPos, xSpawnPos), Random.Range(-ySpawnPos, ySpawnPos));
            var asteroid = ObjectPooler.Instance.GetObject(bulletType);
            asteroid.GetComponent<AsteroidMove>().OnCreate(spawnPosition, transform.rotation);
            Debug.Log(i);
        }
    }
}
