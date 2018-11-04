using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundry;

    private Rigidbody rigidBody;
    private AudioSource audioSource;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space))&& Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();
        }
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //movement = movement.normalized;
        movement = movement * speed * Time.deltaTime;
        rigidBody.velocity = movement;
        //gameObject.transform.Translate(movement * speed * Time.deltaTime);

        rigidBody.position = new Vector3(
            Mathf.Clamp(rigidBody.position.x, boundry.xMin, boundry.xMax),
            0.0f,
            Mathf.Clamp(rigidBody.position.z, boundry.zMin, boundry.zMax)
            );
        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
    }
}
