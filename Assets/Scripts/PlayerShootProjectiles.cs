using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootProjectiles : MonoBehaviour
{
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

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            vfx.transform.localRotation = cam.rotation;
        }
        else
        {
            Debug.Log("No fire point");
        }
    }
}
