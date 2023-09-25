using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMousePosition : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            MoveToMousePos();
        }
    }

    void MoveToMousePos()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Plane plane = new Plane(Vector3.up, new Vector3(0, transform.position.y, 0));

        float enter = 0.0f;
        if (plane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            transform.position = new Vector3(hitPoint.x, hitPoint.y,transform.position.z);
        }
    }
}