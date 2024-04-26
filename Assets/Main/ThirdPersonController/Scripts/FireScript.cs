using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public GameObject firePrefab;
    public ParticleSystem rainParticleSystem;
    // private RainControl rainControl;
    private GameObject currentFire;

    void Start()
    {
        // rainControl = GameObject.FindWithTag("RainControl").GetComponent<RainControl>();
    }

    void OnCollisionEnter(Collision collision)
{
    // Check if the collision is with the log
    if (collision.gameObject.CompareTag("Log"))
    {
        // Get the position of the log
        Vector3 logPosition = collision.gameObject.transform.position;

        // Instantiate fire at the position of the log
        InstantiateFire(logPosition);
        Debug.Log(currentFire);

        Destroy(currentFire, 100.0f);

        // Deactivate the wood stick GameObject
        gameObject.SetActive(false);

        // Destroy the log GameObject
        Destroy(collision.gameObject, 100.0f); // Destroy the log object

        // Disable grabbing for the log object
        ObjectGrabable grabable = collision.gameObject.GetComponent<ObjectGrabable>();
        if (grabable != null)
        {
            grabable.Activate();
        }
    }
}

    void Update()
    {
        // If it's raining and there's a fire, stop the fire particle system
        if (rainParticleSystem != null && rainParticleSystem.isPlaying)
        {
            // If fire exists, extinguish it
            if (currentFire != null)
            {
                ExtinguishFire();
            }
        }
    }

    private void InstantiateFire(Vector3 position)
    {
        // Instantiate fire prefab at the collision position
        currentFire = Instantiate(firePrefab, position, Quaternion.identity);
    }

    private void ExtinguishFire()
    {
        // Destroy the fire object
        Destroy(currentFire);
        currentFire = null;
    }
}
