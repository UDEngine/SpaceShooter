using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    public float tumble;
    private Rigidbody rg;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.angularVelocity = Random.insideUnitSphere * tumble;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
