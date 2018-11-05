using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public GameObject explosion;
    public float tumble;
    public int score;

    private Rigidbody rg;
    private UIController uiController;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.angularVelocity = Random.insideUnitSphere * tumble;
        GameObject go = GameObject.FindWithTag("UIController");
        uiController = go.GetComponent<UIController>();
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
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            pc.KillPlayer();
        }
        else
        {
            uiController.AddScore(score);
        }
        
        Destroy(gameObject);
    }
}