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
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(shootingPoint.forward * shootingForce, ForceMode.Impulse);

    }
}
