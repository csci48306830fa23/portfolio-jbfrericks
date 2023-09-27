using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollector : MonoBehaviour
{
    private SnakeController snake;

    private void Start()
    {
        snake = GetComponentInParent<SnakeController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is a collectible cube
        if (other.CompareTag("CollectibleCube"))
        {
            Destroy(other.gameObject); // Destroy or deactivate the collectible cube
            GameObject newTailCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            snake.AddCubeToTail(newTailCube.transform);
        }
    }
}