using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    Cube cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Cube newCube = GameObject.Instantiate(cube);
            Rigidbody rb = newCube.GetComponent<Rigidbody>();
            rb.position = spawnPoint.position;
        }
    }
}
