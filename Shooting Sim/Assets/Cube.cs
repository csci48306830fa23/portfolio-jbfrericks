using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    float lt = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lt -= Time.deltaTime;
        if(lt < 0 )
        {
            GameObject.Destroy(gameObject);
        }
    }
}
