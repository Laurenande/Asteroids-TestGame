using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private ObjectPooler.ObjectInfo.ObjectType bulletType;
    [SerializeField]
    private Vector3 spawnPosition;
    void Update()
    {
        spawnPosition = transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = ObjectPooler.Instance.GetObject(bulletType);
            bullet.GetComponent<Bullet>().OnCreate(spawnPosition, transform.rotation);
        }
    }
}
