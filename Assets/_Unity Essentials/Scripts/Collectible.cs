using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject onCollectEffect;
    public AudioClip soundEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotationSpeed,0);
                
    }

    void OnTriggerEnter(Collider other)
    {
        // Player Colide Check
        if (other.CompareTag("Player"))
        {

      
        // Instantiate the Particle Effect
        Instantiate(onCollectEffect,transform.position,transform.rotation);
        // Instantiate the Sound Effect
        AudioSource.PlayClipAtPoint(soundEffect,transform.position);
        // Destroy the Collectible
        Destroy(gameObject);
        
        
        }

    }
}
