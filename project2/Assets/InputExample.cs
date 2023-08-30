using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputExample : MonoBehaviour
{
    
    [SerializeField]
    SpawnedObject spawnObjectPrefab;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            GameObject.Instantiate(spawnObjectPrefab);
            Debug.Log("key pressed");
        }   
    }
}
