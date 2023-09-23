using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{


    public GameObject cube;
    public GameObject sphere;
    public GameObject capsule;
    public GameObject cylinder;

    public Transform spawnPoint;
    public Transform spawnPoint2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameObject spawnedObject = Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
            GameObject spawnedObject2 = Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
            GameObject spawnedObject3 = Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
            GameObject spawnedObject4 = Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cube, spawnPoint.position, spawnPoint.rotation);

            //Destroy(spawnedObject, 10f);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject spawnedObject = Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            GameObject spawnedObject2 = Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            Instantiate(cylinder, spawnPoint.position, spawnPoint.rotation);
            //Destroy(spawnedObject, 10f);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject spawnedObject = Instantiate(sphere, spawnPoint.position, spawnPoint.rotation);
            GameObject spawnedObject2 = Instantiate(sphere, spawnPoint.position, spawnPoint.rotation);
            Instantiate(sphere, spawnPoint.position, spawnPoint.rotation);
            Instantiate(sphere, spawnPoint.position, spawnPoint.rotation);
            Instantiate(sphere, spawnPoint.position, spawnPoint.rotation);
            Instantiate(sphere, spawnPoint.position, spawnPoint.rotation);
            Instantiate(sphere, spawnPoint.position, spawnPoint.rotation);
            Instantiate(sphere, spawnPoint.position, spawnPoint.rotation);
            Instantiate(sphere, spawnPoint.position, spawnPoint.rotation);
            Instantiate(sphere, spawnPoint.position, spawnPoint.rotation);
            //Destroy(spawnedObject, 10f);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject spawnedObject = Instantiate(capsule, spawnPoint.position, spawnPoint.rotation);
            GameObject spawnedObject1 = Instantiate(capsule, spawnPoint.position, spawnPoint.rotation);
            Instantiate(capsule, spawnPoint.position, spawnPoint.rotation);
            Instantiate(capsule, spawnPoint.position, spawnPoint.rotation);
            Instantiate(capsule, spawnPoint.position, spawnPoint.rotation);
            Instantiate(capsule, spawnPoint.position, spawnPoint.rotation);
            Instantiate(capsule, spawnPoint.position, spawnPoint.rotation);
            Instantiate(capsule, spawnPoint.position, spawnPoint.rotation);
            Instantiate(capsule, spawnPoint.position, spawnPoint.rotation);
            Instantiate(capsule, spawnPoint.position, spawnPoint.rotation);
            //Destroy(spawnedObject, 10f);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject spawnedObject = Instantiate(cube, spawnPoint2.position, spawnPoint2.rotation);
            Destroy(spawnedObject, 10f);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject spawnedObject = Instantiate(cylinder, spawnPoint2.position, spawnPoint2.rotation);
            Destroy(spawnedObject, 10f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject spawnedObject = Instantiate(sphere, spawnPoint2.position, spawnPoint2.rotation);
            Destroy(spawnedObject, 10f);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject spawnedObject = Instantiate(capsule, spawnPoint2.position, spawnPoint2.rotation);
            Destroy(spawnedObject, 10f);
        }
    }
}
