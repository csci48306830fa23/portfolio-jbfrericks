using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Destory");
        if (collision.gameObject.tag == "Enemy")
        {

            Debug.Log("Destory");
            Destroy(collision.gameObject);
        }
    }
   
}
