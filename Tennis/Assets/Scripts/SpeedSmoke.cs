using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSmoke : MonoBehaviour
{
    public float speedThreshold = 10f; 
    public ParticleSystem particlePrefab; 
    private ParticleSystem particleInstance;
    public TrailRenderer trailRenderer;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Debug.Log(rb.velocity.magnitude);
        //if (rb.velocity.magnitude > speedThreshold)
        //{
        //    if (particleInstance == null)
        //    {
        //        particleInstance = Instantiate(particlePrefab, transform.position, Quaternion.identity, transform);
        //    }
        //    else if (!particleInstance.isPlaying)
        //    {
        //        particleInstance.Play();
        //        particleInstance.transform.position = transform.position;

        //        // Optionally, if the projectile is destroyed or inactive, you can also stop the particles
        //        if (!gameObject.activeSelf)
        //        {
        //            particleInstance.Stop();
        //        }
        //    }
        //}
        //else
        //{
        //    // If the speed is below the threshold and the particles are active, stop them
        //    if (particleInstance != null && particleInstance.isPlaying)
        //    {
        //        particleInstance.Stop();
        //    }
        //}
    }
}
