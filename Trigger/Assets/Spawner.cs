using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject objectPrefab;
    public Vector3 spawnCenter;
    public Vector3 spawnSize;
    public float interval = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnObjects()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnCenter.x - spawnSize.x / 2, spawnCenter.x + spawnSize.x / 2),
            0.5f,
            Random.Range(spawnCenter.z - spawnSize.z / 2, spawnCenter.z + spawnSize.z / 2));
        Instantiate(objectPrefab, randomPosition, Quaternion.identity);
    }

    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            spawnObjects();
        }
    }
}
