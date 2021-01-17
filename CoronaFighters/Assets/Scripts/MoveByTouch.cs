using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{

    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        //Any touches?
        if (Input.touchCount > 0)
        {
            //First touch
            Touch touch1 = Input.GetTouch(0);
            //Touch touch2 = Input.GetTouch(1);
            float timer = 0;
            float tapTime = 0;
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch1.position);

            //Start a timer when touch has begun
            if (touch1.phase == TouchPhase.Began) 
            {
            timer = Time.time;
            }

            //Holding down the finger
            if (touch1.phase == TouchPhase.Stationary)
            {
                if (touchPosition.x > 1)
                {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                }
                //Left side
                else
                {
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                }
            }

            //Jumping
            else if (touch1.phase == TouchPhase.Ended)
            {
                /* 
                tapTime = Time.time - timer;
                if (tapTime < 20)
                {
                    transform.Translate(0, 10, 0);


                }
*/
            }
        }
         
    }

//This is for controlling using the mouse + touch
/* 
    void TouchMove()
    {
       if (Input.GetMouseButton(0))
       {
           Vector3 holdPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

           // Right side of the screen
           if (holdPos.x > 1)
           {
               transform.Translate(moveSpeed, 0, 0);
           }
           //Left side
           else
           {
               transform.Translate(-moveSpeed, 0, 0);
           }
       } 
    }
    */
}
