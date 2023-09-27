using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float cubeSize = 1f; // Assuming the cubes are of size 1x1x1
    public List<Transform> tailCubes = new List<Transform>();

    public void AddCubeToTail(Transform cube)
    {
        tailCubes.Add(cube);
        cube.SetParent(this.transform);

        // Place the cube directly behind the last cube or the head if it's the first one
        Vector3 newPosition = tailCubes.Count == 1 ? transform.position : tailCubes[tailCubes.Count - 2].position;
        newPosition.z -= cubeSize;
        cube.position = newPosition;
    }
}