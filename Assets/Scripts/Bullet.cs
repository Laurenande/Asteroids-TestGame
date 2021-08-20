using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    public ObjectPooler.ObjectInfo.ObjectType Type => type;
    [SerializeField]
    private ObjectPooler.ObjectInfo.ObjectType type;

    private float lifeTime = 3;
    private float currentLifeTime;
    public float speed;

    public void OnCreate(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        currentLifeTime = lifeTime;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if((currentLifeTime -= Time.deltaTime) < 0)
        {
            ObjectPooler.Instance.DestroyObject(gameObject);
        }
    }
}
