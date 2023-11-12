using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils.VRInteraction;

public class RotatableKnob : MonoBehaviour
{
    private Quaternion initialRotation;
    private Vector3 initialPosition;
    private VRMoveable moveable;
    public VRGrabbable moveable1;
    public float maxRotation = 360.0f;
    public AudioSource audioSource;

    void Start()
    {
        initialRotation = transform.localRotation;
        initialPosition = transform.localPosition;
        moveable = GetComponent<VRMoveable>();
        moveable1 = GetComponent<VRGrabbable>();
    }

    void Update()
    {
        
        if (moveable1.GrabbedBy != null)
        {
            
            Vector3 localEulerAngles = moveable1.transform.localEulerAngles;
            float angle = localEulerAngles.y;

            Debug.Log(angle);

            UpdateVolume(angle);
        }
            
    }
    void UpdateVolume(float angle)
    {
        float volume = angle / maxRotation;
        Debug.Log(volume);
        audioSource.volume = volume;
    }
}
