
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

	SpriteRenderer[] sprite;

    int visible = 5; //the number of hs that SHOULD be visible
    int current = 5; // the number of hs so far (hs is removed using a for loop)

   

    // Start is called before the first frame update
    void Start()
    {

		
    }

    // Update is called once per frame
    void Update()
    {

    // ------------------------------------
    if(Input.GetKeyDown(KeyCode.C))
    {   

    Debug.Log(visible);
    Debug.Log(current);
    visible -=1;

    sprite = GetComponentsInChildren<SpriteRenderer>();


    foreach (SpriteRenderer ob in sprite)
            {


                if (current == visible){
                    current = 3;
                    break;
                       }

                current -=1;
                ob.color = new Color(0,0,0,0);

            }
    } // ends for loop
    } // ends update()

    // ----------------------------
}
