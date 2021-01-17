using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanitizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && collision.GetComponent<Player2>().health < 5)
        {
            this.gameObject.SetActive(false);
            collision.GetComponent<Player2>().health += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
