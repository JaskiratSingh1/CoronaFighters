using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public bool faceRight = true;
    public float jumpForce = 5.0f;
    public float sideForce = 1.0f;
    public float maxSpeed = 10.0f;
    public float sideAirForce = 0.1f;
    public float maxAirSpeed = 2.0f;
    public bool hasMask = false;
    bool alive = true;
    UnityEngine.Vector3 jump = new UnityEngine.Vector3(0.0f, 2.0f, 0.0f);
    UnityEngine.Vector3 left = new UnityEngine.Vector3(-2.0f, 0.0f, 0.0f);
    UnityEngine.Vector3 right = new UnityEngine.Vector3(2.0f, 0.0f, 0.0f);
    Rigidbody2D rb;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Masks")
        {
            Destroy(collision.gameObject);
            hasMask = true;
        }
        else if (collision.gameObject.tag == "Mobs" && alive)
        {
            print("death");
            alive = false;
            transform.GetChild(0).Rotate(new UnityEngine.Vector3(0, 0, 90));
            transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            transform.GetChild(1).Rotate(new UnityEngine.Vector3(0, 0, 90));
            transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            rb.velocity = new UnityEngine.Vector3(0, 0, 0);
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
        }

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("collision");
    //    isGrounded = true;
    //}

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                UnityEngine.Vector3 curr = rb.velocity;
                if (curr.x < -(maxSpeed))
                {
                    curr.x = -maxSpeed;
                    rb.velocity = curr;
                }
                else
                {
                    if (isGrounded)
                    {
                        rb.AddForce(left * sideForce, ForceMode2D.Impulse);
                    }
                    else if (curr.x >= -(maxAirSpeed))
                    {
                        rb.AddForce(left * sideAirForce, ForceMode2D.Impulse);
                    }

                }

                if (faceRight)
                {
                    faceRight = false;
                    transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                }
            }

            else if (Input.GetKey(KeyCode.D))
            {
                UnityEngine.Vector3 curr = rb.velocity;
                if (curr.x > maxSpeed)
                {
                    curr.x = maxSpeed;
                    rb.velocity = curr;
                }
                else
                {
                    if (isGrounded)
                    {
                        rb.AddForce(right * sideForce, ForceMode2D.Impulse);
                    }
                    else if (curr.x <= maxAirSpeed)
                    {
                        rb.AddForce(right * sideAirForce, ForceMode2D.Impulse);
                    }
                }

                if (!faceRight)
                {
                    faceRight = true;
                    transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
    }
}
