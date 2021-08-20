using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour, IPooledObject
{
    public ObjectPooler.ObjectInfo.ObjectType Type => type;
    [SerializeField]
    private ObjectPooler.ObjectInfo.ObjectType type;
    public float maxSpeed;
    public float maxRotation;
    public float bottomScreen, upScreen, leftScreen, rightScreen;
    public int asteroidSize;
    private Rigidbody2D rb;
    private ScoreUI scoreUI;

    void Start()
    {
        scoreUI = FindObjectOfType<ScoreUI>();
        rb = GetComponent<Rigidbody2D>();
        Vector2 speed = new Vector2(Random.Range(-maxSpeed, maxSpeed), Random.Range(-maxSpeed, maxSpeed) );
        float rotation = Random.Range(-maxRotation, maxRotation);
        rb.AddForce(speed);
        rb.AddTorque(rotation);

        switch(Type)
        {
            case ObjectPooler.ObjectInfo.ObjectType.Asteroid_Big:
                asteroidSize = 3;
                break;

            case ObjectPooler.ObjectInfo.ObjectType.Asteroid_Medium:
                asteroidSize = 2;
                break;
            case ObjectPooler.ObjectInfo.ObjectType.Asteroid_Small:
                asteroidSize = 1;
                break;
        }

    }


    void Update()
    {
        Vector2 newPos = transform.position;
        if (transform.position.y > upScreen)
        {
            newPos.y = bottomScreen;
        }
        if (transform.position.y < bottomScreen)
        {
            newPos.y = upScreen;
        }
        if (transform.position.x > rightScreen)
        {
            newPos.x = leftScreen;
        }
        if (transform.position.x < leftScreen)
        {
            newPos.x = rightScreen;
        }
        transform.position = newPos;
    }

    public void OnCreate(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            if(asteroidSize == 3)
            {
                for(int i = 1; i < 3; i++)
                {
                    var asteroid = ObjectPooler.Instance.GetObject(ObjectPooler.ObjectInfo.ObjectType.Asteroid_Medium);
                    asteroid.GetComponent<AsteroidMove>().OnCreate(transform.position, transform.rotation);
                }
                scoreUI.scoreInt += 20;
            }
            else if(asteroidSize == 2)
            {
                for (int i = 1; i < 3; i++)
                {
                    var asteroid = ObjectPooler.Instance.GetObject(ObjectPooler.ObjectInfo.ObjectType.Asteroid_Small);
                    asteroid.GetComponent<AsteroidMove>().OnCreate(transform.position, transform.rotation);
                }
                scoreUI.scoreInt += 50;
            }
            else if(asteroidSize == 1)
            {
                scoreUI.scoreInt += 100;
            }
            ObjectPooler.Instance.DestroyObject(gameObject);
        }
        ObjectPooler.Instance.DestroyObject(collision.gameObject);
    }
}
