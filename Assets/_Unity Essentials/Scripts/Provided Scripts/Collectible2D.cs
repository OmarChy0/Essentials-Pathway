using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible2D : MonoBehaviour
{

    public float rotationSpeed = 0.5f;
    public GameObject onCollectEffect;
    public AudioClip soundFx;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0, rotationSpeed);
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        // Check if the other object has a PlayerController2D component
        if (other.GetComponent<PlayerController2D>() != null) {
            
            // Instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);

            // Create a temporary AudioSource
            GameObject soundObject = new GameObject("CollectSound");
            AudioSource audioSource = soundObject.AddComponent<AudioSource>();

            // Set the sound to 2D
            audioSource.spatialBlend = 0f;

            // Set the volume
            audioSource.volume = 1f;

            // Play the collect sound
            audioSource.PlayOneShot(soundFx);

            // Destroy the temporary AudioSource after the sound finishes
            Destroy(soundObject, soundFx.length);
        
            // Destroy the collectible
            Destroy(gameObject);

        }

        
    }


}
