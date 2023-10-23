using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils;

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
        }
    }

    void Shoot()
    {
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
    }
}
