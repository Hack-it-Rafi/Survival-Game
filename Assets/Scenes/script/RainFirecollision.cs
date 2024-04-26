using UnityEngine;

public class RainFirecollision: MonoBehaviour
{
    public GameObject firePrefab;
    public ParticleSystem rainParticleSystem;
    public float speed = 5f;

    private GameObject currentFire;

    private void Start()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void Update()
    {
        // Check if rain is emitting
        if (rainParticleSystem != null && rainParticleSystem.isPlaying)
        {
            // If fire exists, extinguish it
            if (currentFire != null)
            {
                ExtinguishFire();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
          // Instantiate fire at the collision position
            InstantiateFire(collision.contacts[0].point);
        
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
