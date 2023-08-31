using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnedObject : MonoBehaviour
{
    float lifeTme = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer myRenderer = GetComponent<MeshRenderer>();
        if (myRenderer != null)
        {
            Material myMaterial = myRenderer.material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifeTme -= Time.deltaTime;
        if (lifeTme < 0){
            GameObject.Destroy(gameObject);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
