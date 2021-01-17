using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed = 40f;
    public int health = 5;
    public bool hasMask = false;
    public bool hasVacc = false;
    public GameObject losingScreen;
    public Animator animator;

    bool alive = true;
    float horizontal_move = 0f;
    bool jump;

    private void Start()
    {
        losingScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        horizontal_move = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Math.Abs(horizontal_move));
        animator.SetBool("Masked", hasMask);

        if (Input.GetButtonDown("Jump"))
        {
            print("Jumping");
            jump = true;
            animator.SetBool("Jumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
    }

    private void FixedUpdate()
    {
        if (health > 0)
        {
            controller.Move(horizontal_move * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
        else if (alive)
        {
            transform.GetChild(0).Rotate(new Vector3(0, 0, 90));
            transform.Rotate(new Vector3(0, 0, -90));
            losingScreen.SetActive(true);
            alive = false;
        }
        else
        {
            controller.Move(0, false, false);
        }
    }
}
