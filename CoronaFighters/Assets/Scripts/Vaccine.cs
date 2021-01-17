using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    public GameObject winningMessage;
    // Start is called before the first frame update
    void Start()
    {
        winningMessage.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (collision.GetComponent<Player2>().hasVacc)
            {
                winningMessage.SetActive(true);
            }
            else
            {
                collision.GetComponent<Player2>().hasVacc = true;
            }
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
