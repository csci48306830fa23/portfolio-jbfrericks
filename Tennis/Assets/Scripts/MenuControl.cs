using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject ball;
    public Transform spawnPoint;
    public Vector3 forceDirection = Vector3.zero;
    public float forceMagnitude = 5f;
    public bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        if (!running)
        {
            running = true;
            StartCoroutine(SpawnAndApplyForce());
        }
    }
    IEnumerator SpawnAndApplyForce()
    {
        while (running)
        {
            GameObject ballInstance = Instantiate(ball, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(0.1f);

            Rigidbody rb = ballInstance.GetComponent<Rigidbody>();

            if (rb) 
            {
                rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
                StartCoroutine(DestroyBall(ballInstance));
            }
            else
            {
                Debug.LogError("The ball prefab does not have a Rigidbody component!");
            }
            yield return new WaitForSeconds(3f);
            //Destroy(ballInstance);
            
        }
    }

    IEnumerator DestroyBall(GameObject ballToDestroy)
    {
        yield return new WaitForSeconds(10f);
        Destroy(ballToDestroy);
    }
}
