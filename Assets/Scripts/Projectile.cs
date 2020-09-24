using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject muzzlePrefab;
    public GameObject projectileHitPrefab;

    public float damage;
    public float speed;
    public float fireRate;
    public float impactForce;

    // Start is called before the first frame update
    void Start()
    {
        if (muzzlePrefab != null)
        {
            var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
        }
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("NoSpeed");
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        speed = 0;

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if (projectileHitPrefab != null)
        {
            var hitVFX = Instantiate(projectileHitPrefab, pos, rot);
        }

        Destroy(gameObject);
        Debug.Log(collision.transform.name);

        Target target = collision.transform.GetComponent<Target>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }

        if (collision.rigidbody != null)
        {
            collision.rigidbody.AddForce(gameObject.transform.forward * impactForce);
        }

    }
}
