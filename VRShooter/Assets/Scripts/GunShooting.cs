using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils;

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


        }
    }

    void Shoot()
    {

        // Instantiate the projectile

        Quaternion rotatedForward = Quaternion.Euler(shootingPoint.eulerAngles.x, shootingPoint.eulerAngles.y, shootingPoint.eulerAngles.z + 90);

        // Instantiate the projectile with the new rotation
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, rotatedForward);

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
