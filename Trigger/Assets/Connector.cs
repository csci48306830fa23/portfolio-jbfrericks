using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{

    private Material newMaterial;
    private FixedJoint fj;
    public float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fj == null || fj.connectedBody == null)
        {
            float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            transform.Translate(moveX, 0, moveZ);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.color = Random.ColorHSV();

        if (other.gameObject.GetComponent<Renderer>() != null && GetComponent<Renderer>() != null)
        {
            other.gameObject.GetComponent<Renderer>().material = newMaterial;
            GetComponent<Renderer>().material = newMaterial;
        }

        Vector3 contactPoint = other.ClosestPoint(transform.position);

        fj = gameObject.AddComponent<FixedJoint>();
        fj.connectedBody = other.gameObject.GetComponent<Rigidbody>();

        fj.connectedAnchor = other.transform.InverseTransformPoint(contactPoint);

        updateColor();
    }
    void updateColor()
    {
        FixedJoint[] joints = FindObjectsOfType<FixedJoint>();
        foreach (FixedJoint joint in joints)
        {
            Renderer renderer = joint.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = newMaterial;
            }
            if (joint.connectedBody != null)
            {
                Renderer connectedRenderer = joint.connectedBody.GetComponent<Renderer>();
                if (connectedRenderer != null)
                {
                    connectedRenderer.material = newMaterial;
                }
            }
        }
    }
}
