using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psa : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        target.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        target.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
