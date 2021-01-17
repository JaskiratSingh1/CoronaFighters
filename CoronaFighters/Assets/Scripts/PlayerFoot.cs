using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.GetComponent<Player>().isGrounded = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
