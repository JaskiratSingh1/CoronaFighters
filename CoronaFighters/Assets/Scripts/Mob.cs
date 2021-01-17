using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mob : MonoBehaviour
{
    public Vector3 speed = new Vector3(3.0f, 0.0f, 0.0f);
    public bool faceRight = true;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        print(transform.GetChild(0).name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            print("Character");
        }
        else
        {
            Vector2 contactPoint = collision.contacts[0].point;
            Vector2 center = collision.collider.bounds.center;
            if (contactPoint.x > center.x)
            {
                faceRight = true;
                print("collision right");
            }
            else if (contactPoint.x < center.x)
            {
                faceRight = false;
                print("collision left");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (faceRight)
        {
            rb.velocity = speed;
        } else
        {
            rb.velocity = -speed;
        }
    }
}
