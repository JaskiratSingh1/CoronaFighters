
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

	public Transform hb;
	public GameObject h;

    // Start is called before the first frame update
    void Start()
    {
    	// In hiearchy, gameobject called HealthBar with 5 hand sanitizers as its child objects.


		hb = this.gameObject.transform.GetChild(0); // Getting the first child (the rightmost hand sanitizer)

		// to remove hand sanitizer, either make it invisible or just destroy it?
		hb.GetComponent<Renderer>().enabled = false;
		Destroy (transform.GetChild (0));

		//CURRENTLY: no error messages or warnings, but not destroying the child?
		
    }

    // Update is called once per frame
    void Update()
    {

    }
}
