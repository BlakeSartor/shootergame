using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootProjectiles : MonoBehaviour
{
    public Camera fpsCam;

    public float gunRange = 100f;

    public Transform cam;
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();

    private GameObject effectToSpawn;

    private void Start()
    {
        effectToSpawn = vfx[0];
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;
        Vector3 aimPoint;
        if (firePoint != null)
        {
            RaycastHit rayHit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, gunRange))
            {
                aimPoint = rayHit.point;
                
            }
            else
            {
                aimPoint = fpsCam.transform.position + fpsCam.transform.forward * gunRange;
            }

            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            vfx.transform.LookAt(aimPoint);
        }
        else
        {
            Debug.Log("No fire point");
        }
    }
}
