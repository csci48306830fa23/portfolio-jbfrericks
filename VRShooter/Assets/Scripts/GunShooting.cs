using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils;
<<<<<<< HEAD
using VelUtils.VRInteraction;

public class GunShooting : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform shootingPoint;
    public float shootingForce; 
    public Side side = Side.Right;
    private VRMoveable moveable;

    private void Start()
    {
        moveable = GetComponent<VRMoveable>();
    }
    // Update is called once per frame
    void Update()
    {
        if (moveable.GrabbedBy != null)
        {


            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            if (InputMan.Button2Down(side))
            {
                Shoot();
            }
=======

public class GunShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // The prefab of the object you want to shoot
    public Transform shootingPoint; // The point from which the projectiles will be instantiated
    public float shootingForce = 10f; // The force applied to the projectile to make it move
    public Side side = Side.Right;
    // Update is called once per frame
    void Update()
    {
        // Check for input
        if (Input.GetButtonDown("Fire1")) // This assumes you have an input set up named "Fire1"
        {
            Shoot();
        }
        if (InputMan.Button2Down(side))
        {
            Shoot();
>>>>>>> eafaff94b692493057070e295e6f26742cdbb3e1
        }
    }

    void Shoot()
    {
<<<<<<< HEAD
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(shootingPoint.forward * shootingForce, ForceMode.Impulse);

=======
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);

        // Apply force to the projectile to make it move
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        if (projectileRb != null)
        {
            projectileRb.AddForce(shootingPoint.forward * shootingForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Projectile does not have a Rigidbody component");
        }
>>>>>>> eafaff94b692493057070e295e6f26742cdbb3e1
    }
}
