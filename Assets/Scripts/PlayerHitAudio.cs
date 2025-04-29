using UnityEngine;

public class PlayerHitAudio : MonoBehaviour
{
    [SerializeField] private AudioSource playerHitSound; // Serialize the field for the player hit sound.

    public void PlayPlayerHitSound()
    {
        if (playerHitSound != null)
        {
            playerHitSound.Play(); // Play the player hit sound.
        }
    }
}
