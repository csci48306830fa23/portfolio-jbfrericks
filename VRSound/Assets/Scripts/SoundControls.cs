using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControls : MonoBehaviour
{


    public float maxRotation = 270f;
    private Quaternion initialRotation;
    private float currentAngle = 0f;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the angle of rotation around the local Y axis
        Quaternion currentRotation = transform.localRotation;
        Quaternion rotationDifference = currentRotation * Quaternion.Inverse(initialRotation);

        // Assuming the knob rotates around the up vector
        currentAngle = rotationDifference.eulerAngles.y;

        // Normalize the angle
        currentAngle = (currentAngle > 180f) ? currentAngle - 360f : currentAngle;
        currentAngle = Mathf.Clamp(currentAngle, 0f, maxRotation);
        Debug.Log(currentAngle);
        // Use currentAngle to update the volume
        UpdateVolume(currentAngle);
    }

    void UpdateVolume(float angle)
    {
        float volume = angle / maxRotation;
        Debug.Log(volume);
        audioSource.volume = volume;
    }
}
