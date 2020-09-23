using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed;
    public float fireRate;
    public float impactForce;

    // Start is called before the first frame update
    void Start()
    {
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
