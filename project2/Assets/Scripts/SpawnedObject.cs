using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnedObject : MonoBehaviour
{
    float lifeTme = 10;
    public Material[] materials;
    public Renderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        if (materials.Length > 0)
        {
            myRenderer.material = materials[0];
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
    public void ChangeMaterial()
    {
        // If no materials assigned or only one, just return
        if (materials.Length <= 1)
        {
            Debug.LogWarning("Insufficient materials assigned to switch.");
            return;
        }

        // Find the current material's index
        int currentIndex = System.Array.IndexOf(materials, myRenderer.material);

        // If the material is not in the list or it's the last one, set to the first material
        if (currentIndex == -1 || currentIndex == materials.Length - 1)
        {
            myRenderer.material = materials[1];
        }
        else
        {
            // Set to the next material
            myRenderer.material = materials[currentIndex + 1];
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //GameObject.Destroy(gameObject);
        ChangeMaterial();
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
