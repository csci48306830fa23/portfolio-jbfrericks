using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{

    [SerializeField]
    Transform rayOrigin;
   //[SerializeField]
    GameObject rayTarget;

    //Transform rayTarget;
    Vector3 direction;
    float mult = 5.0f;
    // Start is called before the first frame update
    Rigidbody rb;

    void Start()
    {
       // rb = rayTarget.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //getDistance();
    }
    // Update is called once per frame
    void Update()
    {
        getDistance();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootObject();
        }
    }

    void getDistance()
    {
        RaycastHit hit;
        //direction = rayTarget.position - rayOrigin.position;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit))
        {
            Debug.DrawLine(rayOrigin.position, rayOrigin.position + rayOrigin.forward * hit.distance, Color.red);
          
            float distance = Vector3.Distance(rayOrigin.position, hit.point);

            rb = hit.rigidbody;
            direction = hit.transform.position - rayOrigin.position;
            Debug.Log("Distance between the object and raycast is " + distance);
                    
        }
        else
        {
            Debug.Log("No object being hit");
        }
    }

    void shootObject()
    {
        rb.AddForce(direction * mult, ForceMode.Impulse);
    }
}
