using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float powerSpeed;
    public float powerRot;
    public float bottomScreen, upScreen, leftScreen, rightScreen;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 newPos = transform.position;
        if(transform.position.y > upScreen)
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
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * powerRot * Time.deltaTime);
        rb.AddForce(transform.up * powerSpeed * Input.GetAxis("Vertical"));
        //rb.AddTorque(-Input.GetAxis("Horizontal"));
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * powerSpeed;
        }
    }
}
