using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Connector2 : MonoBehaviour
{
    private Material newMaterial;
    private FixedJoint fj;
    public float moveSpeed = 5.0f;
    public AudioClip sound;
    public AudioSource source;
    public bool canAttach = true;
    void Update()
    {
        //if (fj == null || fj.connectedBody == null)
        //{
        //    float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //    float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        //    transform.Translate(moveX, 0, moveZ);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        Connector2 otherObject = other.gameObject.GetComponent<Connector2>();

        // Ensure the object is a CollectibleCube
        if (other.CompareTag("CollectibleCube") && otherObject && otherObject.canAttach && this.canAttach)
        {
            AttachCube(other.gameObject);
        }
    }

    private void AttachCube(GameObject cube)
    {
        cube.transform.SetParent(transform);

        newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.color = Random.ColorHSV();

        if (cube.GetComponent<Renderer>() != null && GetComponent<Renderer>() != null)
        {
            cube.GetComponent<Renderer>().material = newMaterial;
            GetComponent<Renderer>().material = newMaterial;
        }

        Vector3 contactPoint = cube.transform.position; // Using the cube's position directly.

        //fj = gameObject.AddComponent<FixedJoint>();
        //fj.connectedBody = cube.GetComponent<Rigidbody>();
        //fj.connectedAnchor = cube.transform.InverseTransformPoint(contactPoint);

        updateColor();
        source.clip = sound;
        source.Play();
        //this.canAttach = false;
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
