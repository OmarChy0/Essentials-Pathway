using UnityEngine;
using TMPro;
using System;

public class UpdateCollectibleCount : MonoBehaviour
{
    private TextMeshProUGUI collectibleText;

    public GameObject victoryEffect;

    private bool victoryStarted = false;

    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>();

        if (collectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }

        // Hide victory effect at the beginning
        if (victoryEffect != null)
        {
            victoryEffect.SetActive(false);
        }

        UpdateCollectibleDisplay();
    }

    void Update()
    {
        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        int totalCollectibles = 0;

        // Check and count objects of type Collectible
        Type collectibleType = Type.GetType("Collectible");

        if (collectibleType != null)
        {
#if UNITY_6000_3_OR_NEWER
            totalCollectibles += FindObjectsByType(collectibleType).Length;
#else
            totalCollectibles += FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
#endif
        }

        // Check and count objects of type Collectible2D
        Type collectible2DType = Type.GetType("Collectible2D");

        if (collectible2DType != null)
        {
#if UNITY_6000_3_OR_NEWER
            totalCollectibles += FindObjectsByType(collectible2DType).Length;
#else
            totalCollectibles += FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
#endif
        }

        // Update the text
        if (totalCollectibles > 0)
        {
            collectibleText.text = $"Collectibles remaining: {totalCollectibles}";
        }

        // All collectibles collected
        if (totalCollectibles == 0 && !victoryStarted)
        {
            victoryStarted = true;

            // Change text to VICTORY
            collectibleText.text = "VICTORY!";

            // Show victory particle effect
            if (victoryEffect != null)
            {
                victoryEffect.SetActive(true);

                // Play the particle system
                ParticleSystem particles = victoryEffect.GetComponent<ParticleSystem>();

                if (particles != null)
                {
                    particles.Play();
                }
            }
        }
    }
}